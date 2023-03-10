// ACS712XX.h

#ifndef _ACS712XX_h
#define _ACS712XX_h

#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif

#define ACS712_05B_SENSITIVITY    185     // mV/A
#define ACS712_20A_SENSITIVITY    100     // mV/A
#define ACS712_30A_SENSITIVITY    66      // mV/A

enum ACS712XXType {
	ACS712_05B = 0,
	ACS712_20A = 1,
	ACS712_30A = 2,
	ACS712XX_N = 3
};

class ACS712XX {
public:
	ACS712XX(ACS712XXType _type, uint8_t _pin, uint8_t _adc_ref = 5, int _adc_fs = 1023);
	float autoCalibrate();
	float getAC(float _freq = 50.0, float _n_total_period = 1.0);
	float getDC(int _count = 10);
	float getOffset() { return offset; }
	float getSensitivity() { return 1000.0 / inv_sensitivity; }
	void setOffset(float _offset) { offset = _offset; }
	void setSensitivity(float _sen);
	void reset();

private:
	uint8_t sensor_sen[ACS712XX_N] = { ACS712_05B_SENSITIVITY,
									  ACS712_20A_SENSITIVITY,
									  ACS712_30A_SENSITIVITY };
	float inv_sensitivity;
	float results_adjuster;
	float offset;
	int adc_fs;
	uint8_t ACS712XX_pin;
	ACS712XXType type;
};


#endif

