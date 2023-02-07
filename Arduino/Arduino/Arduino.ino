/*
  Name:    Arduino.ino v2.02
  Created: 9/24/2022 12:17:46 PM
  Author:  Jakkapan
*/
//*********************** INPUT Sensor ***********************//
#include <Arduino.h>
#include <Wire.h>
#include <Adafruit_INA219.h>
#include "ACS712.h"
#include "TM1637Display.h"
#include <PINOUT.h>
#include <BUTTON.h>

// Display TM1637
#define CLK 10
#define DIO 11
#define TEST_DELAY 500

//*********************** INPUT Sensor ***********************//
/* 
 * Up to 4 boards may be connected. Addressing is as follows:
 * Board 0: Address = 0x40 Offset = binary 00000 (no jumpers required)
 * Board 1: Address = 0x41 Offset = binary 00001 (bridge A0 as in the photo above)
 * Board 2: Address = 0x44 Offset = binary 00100 (bridge A1)
 * Board 3: Address = 0x45 Offset = binary 00101 (bridge A0 & A1)
*/
Adafruit_INA219 ina219_A(0x40);
Adafruit_INA219 ina219_B(0x41);

const uint8_t SEG_DONE[] = {
  SEG_B | SEG_C | SEG_D | SEG_E | SEG_G,          // d
  SEG_A | SEG_B | SEG_C | SEG_D | SEG_E | SEG_F,  // O
  SEG_C | SEG_E | SEG_G,                          // n
  SEG_A | SEG_D | SEG_E | SEG_F | SEG_G           // E
};

const uint8_t SEG_PASS[] = {
  SEG_A | SEG_B | SEG_G | SEG_E | SEG_F,          // P
  SEG_A | SEG_B | SEG_C | SEG_E | SEG_F | SEG_G,  // A
  SEG_A | SEG_F | SEG_G | SEG_C | SEG_D,          // S
  SEG_A | SEG_F | SEG_G | SEG_C | SEG_D | SEG_DP  // S.
};

const uint8_t SEG_FAIL[] = {
  SEG_A | SEG_F | SEG_G | SEG_E,                  // F
  SEG_A | SEG_B | SEG_C | SEG_E | SEG_F | SEG_G,  // A
  SEG_E | SEG_F,                                  // I
  SEG_D | SEG_E | SEG_F,                          // L

};

const uint8_t SEG_WAIT[] = {
  SEG_G,  // -
  SEG_G,  // -
  SEG_G,  // -
  SEG_G,  // -

};
TM1637Display display(CLK, DIO);
//*********************** Output Control ***********************//

PINOUT RearCAM_Vplus(53);   // Relay RearCAM_V+ A5-D59 //
PINOUT RearCAM_Vminus(51);  // Relay RearCAM_V- A4-D58 //
PINOUT BAT(49);             // Relay BAT_ONOFF A7-D61 //
PINOUT ACC(47);             // Relay ACC_ONOFF A6-D60 //

PINOUT Alarm_Red(45);
PINOUT Alarm_Yellow(43);
PINOUT Alarm_Green(41);
PINOUT Alarm_Sound(39);

// PINOUT SLN45_BT1(52);  // Relay SLN45_BT1 D50 //
// PINOUT SLN45_BT2(50);  // Relay SLN45_BT2 D51 //
// PINOUT SLN45_BT3(48);  // Relay SLN45_BT3 D52 //
// PINOUT SLN45_BT4(46);  // Relay SLN45_BT4 D53 //

PINOUT SLN45_BT1(46);  // Relay SLN45_BT1 D50 //
PINOUT SLN45_BT2(48);  // Relay SLN45_BT2 D51 //
PINOUT SLN45_BT3(50);  // Relay SLN45_BT3 D52 //
PINOUT SLN45_BT4(52);  // Relay SLN45_BT4 D53 //


PINOUT SLN90_BT1(44);  // Relay SLN90_BT1 D46 //
PINOUT SLN90_BT2(42);  // Relay SLN90_BT2 D47 //
PINOUT SLN90_BT3(40);  // Relay SLN90_BT3 D48 //
PINOUT SLN90_BT4(38);  // Relay SLN90_BT4 D59 //

// PINOUT PLAY_SOUND_S1(34, true);  // Relay SLN90_BT3 D48 //
// PINOUT PLAY_SOUND_S2(36, true);  // Relay SLN90_BT4 D59 //

BUTTON SW_Selector_Auto(9);
BUTTON SW_Selector_Manual(8);

BUTTON SW_Button_Start(22);
BUTTON SW_Button_JudgeOK(23);
BUTTON SW_Button_JudgeNG(24);

//-- Variable Serial Read --//
String inputString = "";      // String to hold incoming data
bool stringComplete = false;  // Whether the string is complete
bool state_connected = false;
bool IsRunning = false;
int judgement = -1;
//*********************** Value ***********************//
unsigned long period = 1000;                                           //ระยะเวลาที่ต้องการรอ 1000 = 1 sce
int period_overspend = -1000;                                          //ระยะเวลาที่ต้องการรอ 1000 = 1 sce
unsigned long last_time_cs = 0, last_time_ms = 0, last_time_wait = 0;  //ประกาศตัวแปรเป็น global เพื่อเก็บค่าไว้ไม่ให้ reset จากการวนloop
int timer_count = 0;
bool isConnectChange = false;

void output_Alarm_off() {
  Alarm_Sound.off();
  Alarm_Green.off();
  Alarm_Yellow.off();
  Alarm_Red.off();
}

//****************** Func Control **********************//
void func_control(String _data) {
  //	Serial.println("D : " + _data);
  /********************************/
  if (_data == "0R01") {
    BAT.off();
  } else if (_data == "1R01") {
    BAT.on();
  }
  /*********************************/
  else if (_data == "0R02") {
    ACC.off();
  } else if (_data == "1R02") {
    ACC.on();
  }
  /*********************************/
  else if (_data == "0R03") {
    RearCAM_Vplus.off();
  } else if (_data == "1R03") {
    RearCAM_Vplus.on();
  }
  /*********************************/
  else if (_data == "0R04") {
    RearCAM_Vminus.off();
  } else if (_data == "1R04") {
    RearCAM_Vminus.on();
  }
  /*********************************/
  else if (_data == "0R05") {
    Alarm_Red.off();
  } else if (_data == "1R05") {
    Alarm_Red.on();
  }
  /*********************************/
  else if (_data == "0R06") {
    Alarm_Yellow.off();
  } else if (_data == "1R06") {
    Alarm_Yellow.on();
  }
  /*********************************/
  else if (_data == "0R07") {
    Alarm_Green.off();
  } else if (_data == "1R07") {
    Alarm_Green.on();
  }
  /*********************************/
  else if (_data == "0R08") {
    Alarm_Sound.off();
  } else if (_data == "1R08") {
    Alarm_Sound.on();
  }
  /*********************************/
  else if (_data == "0R09") {
    SLN45_BT1.off();
  } else if (_data == "1R09") {
    SLN45_BT1.on();
  }
  /*********************************/
  else if (_data == "0R10") {
    SLN45_BT2.off();
  } else if (_data == "1R10") {
    SLN45_BT2.on();
  }
  /*********************************/
  else if (_data == "0R11") {
    SLN45_BT3.off();
  } else if (_data == "1R11") {
    SLN45_BT3.on();
  }
  /*********************************/
  else if (_data == "0R12") {
    SLN45_BT4.off();
  } else if (_data == "1R12") {
    SLN45_BT4.on();
  }
  /***************SLN 90******************/
  else if (_data == "0R13") {
    SLN90_BT1.off();
  } else if (_data == "1R13") {
    SLN90_BT1.on();
  }
  /*********************************/
  else if (_data == "0R14") {
    SLN90_BT2.off();
  } else if (_data == "1R14") {
    SLN90_BT2.on();
  }
  /*********************************/
  else if (_data == "0R15") {
    SLN90_BT3.off();
  } else if (_data == "1R15") {
    SLN90_BT3.on();
  }
  /*********************************/
  else if (_data == "0R16") {
    SLN90_BT4.off();
  } else if (_data == "1R16") {
    SLN90_BT4.on();
  }
  // sendSerialCommand(_data);
}
bool isControlKeys(String _data) {

  String data[] = {
    "0R01",
    "1R01",
    "0R02",
    "1R02",
    "0R03",
    "1R03",
    "0R04",
    "1R04",
    "0R05",
    "1R05",
    "0R06",
    "1R06",
    "0R07",
    "1R07",
    "0R08",
    "1R08",
    "0R09",
    "1R09",
    "0R10",
    "1R10",
    "0R11",
    "1R11",
    "0R12",
    "1R12",
    "0R13",
    "1R13",
    "0R14",
    "1R14",
    "0R15",
    "1R15",
    "0R16",
    "1R16",
  };

  for (int i = 0; i < sizeof(data) / sizeof(data[0]); i++) {
    if (data[i] == _data) {
      return true;
    }
  }

  return false;
}
bool toggleBrightness = true;
bool toggleCurrent;
void timeCount() {
  if (millis() - last_time_cs >= period) {



    toggleCurrent = !toggleCurrent;
    if (!state_connected && isConnectChange) {
      toggleBrightness = !toggleBrightness;
      display.setBrightness(5, toggleBrightness);  // on
    } else if (state_connected && isConnectChange) {
      display.setBrightness(5, true);  // on
    }

    //  ina219_A.getCurrent_mA();
    timer_count++;
    if (timer_count > 3600) {
      timer_count = 0;
    }

    last_time_cs = millis();
  } else if (millis() < 1000) {
    last_time_cs = millis();
  }
}
//****************** Func Send data ***********************//
void sendSerialCommand(String msg) {
  Serial.println(">" + msg + "<#");
}
void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    if (inChar == '#') {
      stringComplete = true;  // Set state complete to true
      inputString.trim();
      break;
    }
    if (inChar == '>' || inChar == '<' || inChar == '\n' || inChar == '\r' || inChar == '\t' || inChar == ' ' || inChar == '?') {
      continue;
    }
    inputString += inChar;
  }
}

void setup() {
  //
  Serial.begin(115200);
  // ina219_A.begin();
  // ina219_B.begin();
  sendSerialCommand("Starting.......");
  uint8_t data[] = { 0xff, 0xff, 0xff, 0xff };
  uint8_t blank[] = { 0x00, 0x00, 0x00, 0x00 };
  display.setBrightness(5);
  //display.showNumberHexEx(0xbaaa);        // Expect: f1Af
  display.clear();
  display.setSegments(SEG_WAIT);
  delay(TEST_DELAY);
  display.setBrightness(5, false);  // off
  display.setSegments(SEG_WAIT);
  delay(TEST_DELAY);
  display.setBrightness(5, true);  // on
  display.setSegments(SEG_WAIT);
  delay(TEST_DELAY);

  // SLN90_BT4.on();
}
bool state_btn_Start, state_btn_OK, state_btn_NG;
void func_button() {

  if (SW_Button_Start.getState() && state_btn_Start) {
    IsRunning = true;
    judgement = -1;
    state_btn_Start = false;
    sendSerialCommand("start");
  } else if (!SW_Button_Start.getState()) {
    state_btn_Start = true;
  }

  if (SW_Button_JudgeNG.getState() && state_btn_NG) {
    judgement = 0;
    state_btn_NG = false;
    sendSerialCommand("NG");
  } else if (!SW_Button_JudgeNG.getState()) {
    state_btn_NG = true;
  }

  if (SW_Button_JudgeOK.getState() && state_btn_OK) {
    judgement = 1;
    state_btn_OK = false;
    sendSerialCommand("OK");
  } else if (!SW_Button_JudgeOK.getState()) {
    state_btn_OK = true;
  }
}

void loop() {

  func_button();

  //-- Received data --//
  if (stringComplete == true) {
    // If received image
    if (inputString == "NG" || inputString == "PASS") {
      if (inputString == "NG") {
        judgement = 0;
      } else if (inputString == "PASS") {
        judgement = 1;
      }

    } else if (inputString == "conn") {
      state_connected = true;
      isConnectChange = true;
      sendSerialCommand(inputString);
    } else if (inputString == "close") {
      state_connected = false;
      isConnectChange = true;
    } else if (inputString == "run") {
      IsRunning = true;
      judgement = -1;
    } else if (inputString == "end") {
      IsRunning = false;
    }

    // For control
    if (state_connected && isControlKeys(inputString)) {
      func_control(inputString);
    }
    inputString = "";        // Clear string to empty
    stringComplete = false;  // Reset string is complete to false
  }
  timeCount();
}