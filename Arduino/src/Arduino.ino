/*
  Name:    Arduino.ino
  Created: 9/24/2022 12:17:46 PM
  Author:  Jakkapan
*/
//*********************** INPUT Sensor ***********************//

#include <Wire.h>
#include <Adafruit_INA219.h>
#include <ACS712.h>
#include <TM1637Display.h>
#include <PINOUT.h>
#include <BUTTON.h>
//#include "lib/ACS712XX.h"

// Module connection pins (Digital Pins)
#define CLK 41
#define DIO 40
#define TEST_DELAY   1000

//*********************** INPUT Sensor ***********************//
/* 
 * Up to 4 boards may be connected. Addressing is as follows:
 * Board 0: Address = 0x40 Offset = binary 00000 (no jumpers required)
 * Board 1: Address = 0x41 Offset = binary 00001 (bridge A0 as in the photo above)
 * Board 2: Address = 0x44 Offset = binary 00100 (bridge A1)
 * Board 3: Address = 0x45 Offset = binary 00101 (bridge A0 & A1)
*/
Adafruit_INA219 ina219_A;
Adafruit_INA219 ina219_B(0x41);


void(*resetFunc) (void) = 0;  // declare reset fuction at address 0

const uint8_t SEG_DONE[] =
{
	SEG_B | SEG_C | SEG_D | SEG_E | SEG_G,           // d
	SEG_A | SEG_B | SEG_C | SEG_D | SEG_E | SEG_F,   // O
	SEG_C | SEG_E | SEG_G,                           // n
	SEG_A | SEG_D | SEG_E | SEG_F | SEG_G            // E
};

const uint8_t SEG_PASS[] =
{
SEG_A | SEG_B | SEG_G | SEG_E | SEG_F,				// P
SEG_A | SEG_B | SEG_C | SEG_E | SEG_F | SEG_G,		// A
SEG_A | SEG_F | SEG_G | SEG_C | SEG_D ,				// S
SEG_A | SEG_F | SEG_G | SEG_C | SEG_D | SEG_DP      // S.
};

const uint8_t SEG_FAIL[] =
{
	SEG_A | SEG_F | SEG_G | SEG_E,						// F
	SEG_A | SEG_B | SEG_C | SEG_E | SEG_F | SEG_G,		// A
	SEG_E | SEG_F,										// I
	SEG_D | SEG_E | SEG_F,								// L

};

const uint8_t SEG_WAIT[] =
{
	SEG_G,											// -
	SEG_G,											// -
	SEG_G,											// -
	SEG_G,											// -

};
TM1637Display display(CLK, DIO);

uint8_t SW_Selector_Auto = 23;    // SW_Selector_Auto AD0-D23 //
uint8_t SW_Selector_Manual = 22;  // SW_Selector_Manual AD2-D22 //
uint8_t SW_Button_Wait = 29;    // SW_Button_Wait A13-D32 //

uint8_t SW_Button_JudgeNG = 27;   // SW_Button_JudgeNG AD4-D26 //
uint8_t SW_Button_JudgeOK = 26;   // SW_Button_JudgeOK AD6-D28 //
uint8_t SW_Button_Start = 24;   // SW_Button_Start A15-D30 //


//*********************** Output Control ***********************//
PINOUT Alarm_Red(54);
PINOUT Alarm_Yellow(55);
PINOUT Alarm_Green(56);     // Relay Alarm Green A1-D55 //
PINOUT Alarm_Sound(57);     // Relay Alarm sound A0-D54 //

PINOUT BAT(58);       // Relay BAT_ONOFF A7-D61 //
PINOUT ACC(59);       // Relay ACC_ONOFF A6-D60 //
PINOUT RearCAM_Vplus(60);     // Relay RearCAM_V+ A5-D59 //
PINOUT RearCAM_Vminus(61);    // Relay RearCAM_V- A4-D58 //

PINOUT SLN45_BT1(50);       // Relay SLN45_BT1 D50 //
PINOUT SLN45_BT2(51);       // Relay SLN45_BT2 D51 //
PINOUT SLN45_BT3(52);       // Relay SLN45_BT3 D52 //
PINOUT SLN45_BT4(53);       // Relay SLN45_BT4 D53 //

PINOUT SLN90_BT1(46);       // Relay SLN90_BT1 D46 //
PINOUT SLN90_BT2(47);       // Relay SLN90_BT2 D47 //
PINOUT SLN90_BT3(48);       // Relay SLN90_BT3 D48 //
PINOUT SLN90_BT4(49);       // Relay SLN90_BT4 D59 //

PINOUT PLAY_SOUND_S1(34,true);       // Relay SLN90_BT3 D48 //
PINOUT PLAY_SOUND_S2(36,true);       // Relay SLN90_BT4 D59 //

//-- Variable --//
String inputString = "";      // String to hold incoming data
bool stringComplete = false;    // Whether the string is complete

bool the_result_Image = false;
bool state_received_Image = false;

bool state_send = false;
bool state_connected = false;

//*********************** Value ***********************//
unsigned long period = 1000;  //ระยะเวลาที่ต้องการรอ 1000 = 1 sce
int period_overspend = -1000; //ระยะเวลาที่ต้องการรอ 1000 = 1 sce
unsigned long last_time_cs = 0, last_time_ms = 0, last_time_wait = 0;  //ประกาศตัวแปรเป็น global เพื่อเก็บค่าไว้ไม่ให้ reset จากการวนloop
bool state_func_auto = false;
int func_item = 0;
bool state_func_item = false;
int timer_count = 0;
int func_time_next = 0;

bool state_func_manual = false;;
int failCount = 0;
int lastStep;
uint8_t current = 0;
// ACS712 sensor_current_BAT(ACS712_05B, A15);		//Sensor A15 BAT//
// ACS712XX Sensor_current_ACC(ACS712_05B, A14);		//Sensor A14 ACC//


//AUTOMATIC_FUNCTION func_Auto45(&Serial);
void output_Alarm_off()
{	Alarm_Sound.off();
		Alarm_Green.off();
		Alarm_Yellow.off();
		Alarm_Red.off();
	switch (inputAlarm)
	{
	case 1:
		Alarm_Sound.on();
		Alarm_Green.off();
		Alarm_Yellow.off();
		Alarm_Red.off();
		break;
	case 2:
		Alarm_Sound.off();
		Alarm_Green.on();
		Alarm_Yellow.off();
		Alarm_Red.off();
		break;
	case 3:
		Alarm_Sound.off();
		Alarm_Green.off();
		Alarm_Yellow.on();
		Alarm_Red.off();
		break;
	case 4:
		Alarm_Sound.off();
		Alarm_Green.off();
		Alarm_Yellow.off();
		Alarm_Red.on();
		break;
	default:
		Alarm_Sound.off();
		Alarm_Green.off();
		Alarm_Yellow.off();
		Alarm_Red.off();
		break;
	}
}

void output_DVR(int inputDVR = 0)
{

	BAT.off();       // Relay BAT_ONOFF A7-D61 //
	ACC.off();       // Relay ACC_ONOFF A6-D60 //
	RearCAM_Vplus.off();     // Relay RearCAM_V+ A5-D59 //
	RearCAM_Vminus.off();    // Relay RearCAM_V- A4-D58 //
}

void output_SLN45(int inputSLN45 = 0)
{

	SLN45_BT1.off();       // Relay SLN45_BT1 D50 //
	SLN45_BT2.off();       // Relay SLN45_BT2 D51 //
	SLN45_BT3.off();       // Relay SLN45_BT3 D52 //
	SLN45_BT4.off();       // Relay SLN45_BT4 D53 //
}

void output_SLN90(int inputSLN90 = 0)
{
	SLN90_BT1.off();       // Relay SLN90_BT1 D50 //
	SLN90_BT2.off();       // Relay SLN90_BT2 D51 //
	SLN90_BT3.off();       // Relay SLN90_BT3 D52 //
	SLN90_BT4.off();       // Relay SLN45_BT4 D53 //
}

void setNextItem(int item, int sec = 0, int count = 0)
{
	func_item = item;
	func_time_next = sec;
	timer_count = count;
	last_time_cs = millis();

}
void imageProcessing(String _msg) {
	sendDataToSerialPort("P:" + _msg);
	state_received_Image = false;
}

void testConnected() {
	sendDataToSerialPort("conn:01");
	state_connected = false;
}

bool state_func = false;
int buutonPressed = 0;


bool state_judgement = false;
bool judgement_result = false;
void judgement()
{
	if (digitalRead(SW_Button_JudgeOK) == LOW)
	{
		delay(10);
		while (digitalRead(SW_Button_JudgeOK) == LOW);
		state_judgement = true; // Start judgement
		judgement_result = true;
		Serial.println("Judge OK");

	}
	else if (digitalRead(SW_Button_JudgeNG) == LOW) {
		Serial.println("Judge NG");
		delay(10);
		while (digitalRead(SW_Button_JudgeNG) == LOW);
		state_judgement = true; // State judgement
		judgement_result = false;

	}
}

bool toggle_display = false;
bool state_waiting = false;
uint8_t button_pressed = 0;
void status_wait() {
	if (state_waiting) {
		if (millis() - last_time_wait >= 500)
		{
			// Active every 1 second

			toggle_display = !toggle_display;
			//if (toggle_display) {
			//	Serial.println("Display On");
			//	display.setBrightness(5, true);		// On || Off 
			//	display.setSegments(SEG_PASS);

			//}
			//else
			//{
			//	Serial.println("Display Off");
			//	display.setBrightness(5, toggle_display);		// On || Off 
			//	display.setSegments(SEG_PASS);

			//}

			display.setBrightness(5, toggle_display);		// On || Off 
			//display.setSegments(SEG_PASS);
			display.showNumberDec(func_item, 1);
			last_time_wait = millis();
		}
	}
	else if (toggle_display == false)
	{
		toggle_display = !toggle_display;
		display.setBrightness(5, toggle_display);		// On || Off 
		display.showNumberDec(func_item, 1);
	}
}

void func_judgement(bool mode = true) {
	if (mode)
	{
		/******************** Wait Judgemaent ****************************/
		if (timer_count > func_time_next && !state_func) {
			if (!state_judgement) {
				judgement(); // waiting judgement
				if (!state_waiting)
					state_waiting = true; // Waiting judgement
			}
			else {
				if (!judgement_result) // If fail
				{
					setFail();
					return;
				}
				state_func = true;
				setNextItem(func_item);
			}
		}
		else if (timer_count > func_time_next && state_func) {
			button_pressed = 0;
			state_waiting = false; // Stop waiting judgement
			state_judgement = false; // Reset
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
	}
	else {
		/******************** Wait Judgemaent ****************************/
		if (timer_count > func_time_next && !state_func) {
			if (!state_judgement) {
				judgement(); // waiting judgement
				if (!state_waiting)
					state_waiting = true; // Waiting judgement
			}
			else {
				if (!judgement_result) // If fail
				{
					if (failCount < 3) {
						failCount++;
						//state_func = true;
						setNextItem((func_item - 2),0,1);
						state_judgement = false; // Reset
						state_waiting = false; // Reset
						return;
					}
					setFail();
					return;
				}
				state_func = true;
				setNextItem(func_item);
			}
		}
		else if (timer_count > func_time_next && state_func) {
			failCount = 0;
			button_pressed = 0;
			state_waiting = false; // Stop waiting judgement
			state_judgement = false; // Reset
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
	}
}
void setFail() {
	failCount++;
	state_waiting = false;
	setNextItem(500, 1);
}

void func_manual(bool inputState)
{
	if (!inputState)
	{
		return;
	}

	if (timer_count > 50)
	{
		setFail();
		return;
	}
	switch (func_item)
	{
	case 0:
		if (!state_func)
		{
			output_Alarm();
			output_DVR();
			Alarm_Yellow.on();
			BAT.on();
			state_func = true;
			setNextItem(func_item, 2);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1));
			state_func = false;
		}
		break;
	case 1:
		if (timer_count > func_time_next && !state_func) { // ACC on
			ACC.on();
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 5);
			state_judgement = false; // Reset
			state_func = false;
			state_waiting = false;
		}
		break;
	case 2:
		/******************** Wait Judgemaent ****************************/
		if (timer_count > func_time_next && !state_func) {
			if (!state_judgement) {
				judgement(); // waiting judgement
				state_waiting = true; // Waiting judgement
				return;
			}
			else {
				if (!judgement_result) // If fail
				{
					setFail();
					return;
				}
				state_func = true;
				setNextItem(func_item, 0, 1);
			}
		}
		else if (timer_count > func_time_next && state_func) {

			state_waiting = false; // Stop waiting judgement
			state_judgement = false; // Reset
			setNextItem((func_item + 1));
			state_func = false;
		}
		break;
		/******************** End Wait Judgemaent ****************************/
	case 3:
		if (timer_count > func_time_next && !state_func) { // SLN 4 Pressed 
			SLN45_BT4.on();
			state_func = true;
			setNextItem(func_item, 0, 1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
	case 4:
		/******************** Wait Judgemaent ****************************/
		if (timer_count > func_time_next && !state_func) {
			// Check Icon Lock
			if (!state_judgement) {
				judgement(); // waiting judgement
				if (!state_waiting)
					state_waiting = true; // Waiting judgement
			}
			else {
				if (!judgement_result) // If fail
				{
					setFail();
					return;
				}
				state_func = true;
				setNextItem(func_item, 0, 1);
			}
		}
		else if (timer_count > func_time_next && state_func) {

			state_waiting = false; // Stop waiting judgement
			state_judgement = false; // Reset
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
		/******************** End Wait Judgemaent ****************************/
	case 5:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 
			// Menu
			SLN45_BT1.on();
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
	case 6:
		/******************** Wait Judgemaent ****************************/
		if (timer_count > func_time_next && !state_func) {
			if (!state_judgement) {
				judgement(); // waiting judgement
				if (!state_waiting)
					state_waiting = true; // Waiting judgement
			}
			else {
				if (!judgement_result) // If fail
				{
					setFail();
					return;
				}
				state_func = true;
				setNextItem(func_item, 0, 1);
			}
		}
		else if (timer_count > func_time_next && state_func) {

			state_waiting = false; // Stop waiting judgement
			state_judgement = false; // Reset
			setNextItem((func_item + 1), 0, 1);
			state_func = false;
		}
		break;
		/******************** End Wait Judgemaent ****************************/
	case 7:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 
			// Back to Main
			SLN45_BT1.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			RearCAM_Vplus.on();
			RearCAM_Vminus.on();
			setNextItem((func_item + 1), 10);
			state_func = false;
		}
		break;
	case 8:
		/******************** Wait Judgemaent ****************************/
		if (timer_count > func_time_next && !state_func) {
			// After 10 Sec recording 
			if (!state_judgement) {
				judgement(); // waiting judgement
				if (!state_waiting)
					state_waiting = true; // Waiting judgement
			}
			else {
				if (!judgement_result) // If fail
				{
					setFail();
					return;
				}
				state_func = true;
				setNextItem(func_item, 0, 1);
			}
		}
		else if (timer_count > func_time_next && state_func) {
			state_waiting = false; // Stop waiting judgement
			state_judgement = false; // Reset
			setNextItem((func_item + 1), 0, 1);
			state_func = false;
			button_pressed = 0;

		}
		break;
		/******************** End Wait Judgemaent ****************************/
	case 9:
		if (timer_count > func_time_next && !state_func) { // SLN 3 Pressed 
			// Capture Image
			SLN45_BT3.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
	case 10:
		if (timer_count > func_time_next && !state_func) { // SLN 2 Pressed 
			// Back Camera 
			SLN45_BT2.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1));
			state_func = false;
		}
		break;
	case 11:
		if (timer_count > func_time_next && !state_func) { // SLN 3 Pressed 
			// Capture Image
			SLN45_BT3.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1));
			state_func = false;
		}
		break;
	case 12:
		if (timer_count > func_time_next && !state_func) { // SLN 2 Pressed 
			// Front Camera 
			SLN45_BT2.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1));
			state_func = false;
		}
		break;
	case 13:
		/******************** Wait Judgemaent ****************************/
		func_judgement();
		break;
		/******************** End Wait Judgemaent ****************************/

	case 14:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 
			// Menu
			SLN45_BT1.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 2), 2);
			state_func = false;
		}
		break;
	case 15:
		/******************** Wait Judgemaent ****************************/
		func_judgement();
		break;
		/******************** End Wait Judgemaent ****************************/
	case 16:
		if (timer_count > func_time_next && !state_func) { // SLN 4 Pressed 
			// List of setting
			SLN45_BT4.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
	case 17:
		/******************** Wait Judgemaent ****************************/
		func_judgement();
		break;
		/******************** End Wait Judgemaent ****************************/
	case 18:
		if (timer_count > func_time_next && !state_func) { // SLN 3 Pressed 2 item
			if (button_pressed < 2) {
				button_pressed++;
				SLN45_BT3.on(true);
				setNextItem(func_item);
				return;
			}
			state_func = true;
			setNextItem(func_item,0,1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 2), 0);
			state_func = false;
		}
		break;
	case 19:
		/******************** Wait Judgemaent ****************************/
		func_judgement();
		break;
		/******************** End Wait Judgemaent ****************************/

		/************************** Off sound record ***********************/
	case 20:
		if (timer_count > func_time_next && !state_func) { // SLN 4 Pressed 
		// 
			SLN45_BT4.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
	case 21:
		if (timer_count > func_time_next && !state_func) { // SLN 3 Pressed 
		// Move to off
			SLN45_BT3.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
	case 22:
		if (timer_count > func_time_next && !state_func) { // SLN 4 Pressed 
		// OK
			SLN45_BT4.on(true);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
		/************************** End Off sound record ***********************/
	case 23:
		/******************** Wait Judgemaent ****************************/
		func_judgement(false);
		break;
		/******************** End Wait Judgemaent ****************************/
	case 24:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 3 item
			// Back to main
			if (button_pressed < 3) {
				button_pressed++;
				SLN45_BT1.on(true);
				setNextItem(func_item);
				return;
			}
			button_pressed = 0;
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 7);
			state_func = false;
		}
		break;
	case 25:
		/******************** Wait Judgemaent ****************************/
		func_judgement();
		break;
		/******************** End Wait Judgemaent ****************************/

		/********************* Set Date *****************************/
	case 26:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 
			// Menu
			SLN45_BT1.on(true);
			state_func = true;
			setNextItem(func_item, 0, 1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;

		}
		break;
	case 27:
		if (timer_count > func_time_next && !state_func) { // SLN 4 Pressed 
			// List setting
			SLN45_BT4.on(true);
			state_func = true;
			setNextItem(func_item, 0, 1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
			button_pressed = 0;
		}
		break;
	case 28:
		if (timer_count > func_time_next && !state_func) { // SLN 3 Pressed 4 item
			// Down x4
			if (button_pressed < 4) {
				button_pressed++;
				SLN45_BT3.on(true);
				setNextItem(func_item);
				return;
			}
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
	case 29:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 
			// Ok 
			SLN45_BT4.on(true);
			state_func = true;
			setNextItem(func_item, 0,1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
			button_pressed = 0;
		}
		break;
	case 30:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 
			// Select 
			SLN45_BT3.on(true);
			state_func = true;
			setNextItem(func_item, 0, 1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
			button_pressed = 0;
		}
		break;
	case 31:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 
			// Ok 
			SLN45_BT4.on(true);
			state_func = true;
			setNextItem(func_item, 0, 1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
			button_pressed = 0;
		}
		break;
	case 32:
		/******************** Wait Judgemaent ****************************/
		func_judgement(false);
		break;
	case 33:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 3 item
			// Back 1
			SLN45_BT1.on(true);
			setNextItem(func_item);
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
		/********************* End Set Date *****************************/
		/********************* End Set Time *****************************/
	case 34:
		if (timer_count > func_time_next && !state_func) { // SLN 1 Pressed 2 item
			// Up
			SLN45_BT2.on(true);
			setNextItem(func_item);
			state_func = true;
			setNextItem(func_item,0,1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
	case 35:
		if (timer_count > func_time_next && !state_func) { // SLN 4 Pressed 1 item
			// Back 1
			SLN45_BT4.on(true);
			setNextItem(func_item);
			state_func = true;
			setNextItem(func_item, 0, 1);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((499 + 1), 1);
			state_func = false;
		}
		break;
		///////////////////////////////////////////////////
	case 36:
		if (timer_count > func_time_next && !state_func) { // SLN 4 Pressed 3 item
			if (button_pressed < 3) {
				button_pressed++;
				SLN45_BT4.on(true);
				setNextItem(func_item);
				return;
			}
			button_pressed = 0;
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((499 + 1), 1);
			state_func = false;
		}
		break;
	case 37:
		func_judgement();
		break;
	case 38:
		if (timer_count > func_time_next && !state_func) { // SLN 4 Pressed 3 item
			if (button_pressed < 3) {
				button_pressed++;
				SLN45_BT4.on(true);
				setNextItem(func_item);
				return;
			}
			state_func = true;
			setNextItem(func_item);
		}
		else if (timer_count > func_time_next && state_func) {
			setNextItem((func_item + 1), 1);
			state_func = false;
		}
		break;
		/******************** End Process ********************************/
	case 500:
		if (timer_count > func_time_next) {
			ACC.off();
			setNextItem(501, 2);
			sendDataToSerialPort("end:01");
		}
		break;
	case 501:
		if (timer_count > func_time_next) {
			state_func = false;
			output_DVR(); // Off
			output_Alarm(); // Off
			display.clear();
			if (failCount != 0) {
				sendDataToSerialPort("reset:ng");
				Alarm_Red.on();
				display.setSegments(SEG_FAIL);
			}
			else
			{
				sendDataToSerialPort("reset:pass");
				display.setSegments(SEG_PASS);
				Alarm_Green.on();
			}
			state_func_manual = false;
		}

	}
}

void func_control(String _data)
{
	Serial.println("D : " + _data);
	/********************************/
	if (_data == "0R01")
	{
		BAT.off();
	}
	else if (_data == "1R01")
	{
		BAT.on();
	}
	/*********************************/
	else if (_data == "0R02")
	{
		ACC.off();
	}
	else if (_data == "1R02")
	{
		ACC.on();
	}
	/*********************************/
	else if (_data == "0R03")
	{
		RearCAM_Vplus.off();
	}
	else if (_data == "1R03")
	{
		RearCAM_Vplus.on();
	}
	/*********************************/
	else if (_data == "0R04")
	{
		RearCAM_Vminus.off();
	}
	else if (_data == "1R04")
	{
		RearCAM_Vminus.on();
	}
	/*********************************/
	else if (_data == "0R05")
	{
		Alarm_Red.off();
	}
	else if (_data == "1R05")
	{
		Alarm_Red.on();
	}
	/*********************************/
	else if (_data == "0R06")
	{
		Alarm_Yellow.off();
	}
	else if (_data == "1R06")
	{
		Alarm_Yellow.on();
	}
	/*********************************/
	else if (_data == "0R07")
	{
		Alarm_Green.off();
	}
	else if (_data == "1R07")
	{
		Alarm_Green.on();
	}
	/*********************************/
	else if (_data == "0R08")
	{
		Alarm_Sound.off();
	}
	else if (_data == "1R08")
	{
		Alarm_Sound.on();
	}
	/*********************************/
	else if (_data == "0R09")
	{
		SLN45_BT1.off();
	}
	else if (_data == "1R09")
	{
		SLN45_BT1.on();
	}
	/*********************************/
	else if (_data == "0R10")
	{
		SLN45_BT2.off();
	}
	else if (_data == "1R10")
	{
		SLN45_BT2.on();
	}
	/*********************************/
	else if (_data == "0R11")
	{
		SLN45_BT3.off();
	}
	else if (_data == "1R11")
	{
		SLN45_BT3.on();
	}
	/*********************************/
	else if (_data == "0R12")
	{
		SLN45_BT4.off();
	}
	else if (_data == "1R12")
	{
		SLN45_BT4.on();
	}
	/***************SLN 90******************/
	else if (_data == "0R13")
	{
		SLN90_BT1.off();
	}
	else if (_data == "1R13")
	{
		SLN90_BT1.on();
	}
	/*********************************/
	else if (_data == "0R14")
	{
		SLN90_BT2.off();
	}
	else if (_data == "1R14")
	{
		SLN90_BT2.on();
	}
	/*********************************/
	else if (_data == "0R15")
	{
		SLN90_BT3.off();
	}
	else if (_data == "1R15")
	{
		SLN90_BT3.on();
	}
	/*********************************/
	else if (_data == "0R16")
	{
		SLN90_BT4.off();
	}
	else if (_data == "1R16")
	{
		SLN90_BT4.on();
	}
}

void timeCount() {
	if (millis() - last_time_cs >= period)
	{
		// Active every 1 second
		timer_count++;
		//sendDataToSerialPort("bat:" + (String)sensor_current_BAT.getCurrentDC());
		float shuntvoltage = 0;
		float busvoltage = 0;
		float current_mA = 0;
		float loadvoltage = 0;

		shuntvoltage = ina219_A.getShuntVoltage_mV();
		busvoltage = ina219_A.getBusVoltage_V();
		current_mA = ina219_A.getCurrent_mA();
		loadvoltage = busvoltage + (shuntvoltage / 1000);

		Serial.print("Bus Voltage:   "); Serial.print(busvoltage); Serial.println(" V");
		Serial.print("Shunt Voltage: "); Serial.print(shuntvoltage); Serial.println(" mV");
		Serial.print("Load Voltage:  "); Serial.print(loadvoltage); Serial.println(" V");
		Serial.print("Current:       "); Serial.print(current_mA); Serial.println(" mA");
		Serial.println("");

		last_time_cs = millis();
		//Serial.println("Toggle : " + toggle_display);
	}
	else if (millis() < 1000)
	{
		last_time_cs = millis();
	}

	if (millis() - last_time_ms >= 800)
	{
		if (current == 2) {
			//sendDataToSerialPort("bat:" + (String)sensor_current_BAT.getCurrentDC());
		}
		else if (current == 3)
		{
			//sendDataToSerialPort("acc:" + (String)Sensor_current_ACC.getDC());
		}
		else if (current >= 5)
		{
			current = 0;
		}
		current++;
		last_time_ms = millis();
	}
	else if (millis() < 1000)
	{
		last_time_ms = millis();
	}
}
//****************** Func Send data ***********************//
void sendDataToSerialPort(String msg)
{
	Serial.println(">" + msg + "<#");
}
//***************** Func Received Data ********************//
void serialEvent() {
	while (Serial.available()) {
		// get the new byte:
		char inChar = (char)Serial.read();
		if (inChar == '#') {
			stringComplete = true; // Set state complete to true
			inputString.trim();
			break;
		}
		if (inChar == '>' || inChar == '<' || inChar == '\n' || inChar == '\r' || inChar == '\t' || inChar == ' ' || inChar == '?') {
			continue;
		}
		inputString += inChar;
	}
}

void setup(void)
{
	//*********************** INPUT Sensor ***********************//
	pinMode(SW_Selector_Auto, INPUT_PULLUP);
	pinMode(SW_Selector_Manual, INPUT_PULLUP);
	pinMode(SW_Button_JudgeNG, INPUT_PULLUP);
	pinMode(SW_Button_JudgeOK, INPUT_PULLUP);
	pinMode(SW_Button_Start, INPUT_PULLUP);
	pinMode(SW_Button_Wait, INPUT_PULLUP);
	Serial.begin(115200);
	ina219_A.begin();
  	ina219_B.begin();

	PLAY_SOUND_S1.on(true);
	delay(2000);

	PLAY_SOUND_S2.on(true);
	delay(2000);
	/************************* Sensor BAT *********************************/
	//Serial.println("Calibrating... Ensure that no current flows through the sensor at this moment");
	//int zero = sensor_current_BAT.calibrate();
	//Serial.println("Done!");
 	Serial.println("Starting.......");
	///************************* Sensor ACC *********************************/
	
  // BAT.on();       // Relay BAT_ONOFF A7-D61 //
  // delay(TEST_DELAY);
  // ACC.on();       // Relay ACC_ONOFF A6-D60 //
	uint8_t data[] = { 0xff, 0xff, 0xff, 0xff };
	uint8_t blank[] = { 0x00, 0x00, 0x00, 0x00 };
	display.setBrightness(5);
	//display.showNumberHexEx(0xbaaa);        // Expect: f1Af
	display.clear();
	display.setSegments(SEG_WAIT);
	delay(TEST_DELAY);
	display.setBrightness(5, false);		// off
	display.setSegments(SEG_WAIT);
	delay(TEST_DELAY);
	display.setBrightness(5, true);		// on
	display.setSegments(SEG_WAIT);
	delay(TEST_DELAY);
}
bool stateModeControl = false;
void loop(void) {
	//*********************** Check selector switch Auto ***********************//
	if (digitalRead(SW_Selector_Auto) == LOW && stateModeControl == false)
	{
		if (digitalRead(SW_Button_Start) == LOW)
		{
			delay(10);
			while (digitalRead(SW_Button_Start) == LOW);
			if (!state_func_auto) {
				func_item = 0;
				timer_count = 0;
			}
			state_received_Image = true;
			state_func_auto = true;
			//sendDataToSerialPort("on");
			display.showNumberDec(0, 1);
		}
		//func_Auto45.update();      // 
		func_auto(state_func_auto); // Function Auto

		if (state_func_auto == true) {
			if (lastStep != func_item) {
				display.showNumberDec(func_item, 1);
				lastStep = func_item;
			}
		}
	}
	else if (digitalRead(SW_Selector_Manual) == LOW && stateModeControl == false)
	{
		if (digitalRead(SW_Button_Start) == LOW)
		{
			delay(10);
			while (digitalRead(SW_Button_Start) == LOW);
			if (!state_func_manual) {
				func_item = 0;
				timer_count = 0;
			}
			state_func_manual = true;
		}
		func_manual(state_func_manual); // Function manual

		if (state_func_manual == true) {
			if (lastStep != func_item) {
				display.showNumberDec(func_item, 1);
				lastStep = func_item;
			}
		}
	}

	//-- Received data --//
	if (stringComplete == true)
	{
		// If received image
		if (inputString == "NG" || inputString == "PASS") {
			if (inputString == "NG") {
				the_result_Image = false;
			}
			else if (inputString == "PASS")
			{
				the_result_Image = true;
			}
			// Recvied data from Image Processing
			state_received_Image = true;
		}
		else if (inputString == "conn")
		{
			state_connected = true;
		}
		else if (inputString == "IOOP")
		{
			output_Alarm(0); // Alarm Off //
			output_DVR(); // DVR Off //
			output_SLN45(); // SLN45 Off //
			output_SLN90(); // SLN90 Off //
			stateModeControl = true;
		}
		else if (inputString == "IOCL")
		{
			output_Alarm(); // Alarm Off //
			output_DVR(); // DVR Off //
			output_SLN45(); // SLN45 Off //
			output_SLN90(); // SLN90 Off //
			stateModeControl = false;
		}
		sendDataToSerialPort(inputString);
		if (stateModeControl == true) {
			func_control(inputString);
		}


		inputString = ""; // Clear string to empty
		stringComplete = false; // Reset string is complete to false
	}
	timeCount();

	//*********************** Output Control ***********************//
	// Alarm_Red.update();
	// Alarm_Yellow.update();
	// Alarm_Green.update();		// Relay Alarm Green A1-D55 //
	// Alarm_Sound.update();		// Relay Alarm sound A0-D54 //

	// BAT.update();				// Relay BAT_ONOFF A7-D61 //
	// ACC.update();				// Relay ACC_ONOFF A6-D60 //
	// RearCAM_Vplus.update();     // Relay RearCAM_V+ A5-D59 //
	// RearCAM_Vminus.update();    // Relay RearCAM_V- A4-D58 //

	// SLN45_BT1.update();			// Relay SLN45_BT1 D50 //
	// SLN45_BT2.update();			// Relay SLN45_BT2 D51 //
	// SLN45_BT3.update();			// Relay SLN45_BT3 D52 //
	// SLN45_BT4.update();			// Relay SLN45_BT4 D53 //

	// SLN90_BT1.update();			// Relay SLN90_BT1 D46 //
	// SLN90_BT2.update();			// Relay SLN90_BT2 D47 //
	// SLN90_BT3.update();			// Relay SLN90_BT3 D48 //
	// SLN90_BT4.update();			// Relay SLN90_BT4 D59 //

	status_wait();

}
