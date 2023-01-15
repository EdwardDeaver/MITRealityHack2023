#include <BluetoothSerial.h>
#include <ArduinoJson.h>
BluetoothSerial BTSerial;
StaticJsonDocument<800> doc;

//DIGITAL PINS (BUTTONS)
//(5 for frets)
#define BTN_1 13
#define BTN_2 12
#define BTN_3 14
#define BTN_4 27

//strum
#define BTN_5 26
#define BTN_6 25

// //2 for Whammy
// #define WHAM_1  //same as uart 2 rx
// #define WHAM_2

// //4 for dpad
// #define DPAD_1 
// #define DPAD_2 
// #define DPAD_3 
// #define DPAD_4 

// //2 for back/start
// #define BS_1 
// #define BS_2 

// //Joystick (2 analog, 1 d)
// #define JOY_1 
// #define JOY_2 
// #define JOY_3 

//ANALOG PINS
//(POT)
#define POT_1 34
#define POT_2 35
#define POT_3 32
// #define POT_4 
// #define POT_5 

int pot1, pot2, pot3, btn1, btn2, btn3, btn4, btn5, btn6;

void setup() {
  //POTS
  pinMode(POT_1, INPUT);
  pinMode(POT_2, INPUT);
  pinMode(POT_3, INPUT);
  //BTNS

  pinMode(BTN_1, INPUT_PULLUP);
  pinMode(BTN_2, INPUT_PULLUP);
  pinMode(BTN_3, INPUT_PULLUP);
  pinMode(BTN_4, INPUT_PULLUP);
  pinMode(BTN_5, INPUT_PULLUP);
  pinMode(BTN_6, INPUT_PULLUP);

  //BT x SERIAL
  String name = "Guitar-ESP32";
  Serial.begin(9600);
  BTSerial.begin(name);
  Serial.println("Bluetooth Started... Called: " + name);
  doc["status"] = "running";
  doc["name"] = name;

}

void UpdateJson(String field, int value){
  doc[field] = value; 
}

int pot1values[8];
int counter = 0;
int smoothing = 8;
void loop() {
  // put your main code here, to run repeatedly:

  if (counter == smoothing) {
    counter = 0;
  }
  pot1values[counter] = analogRead(POT_1);
  counter++;
  pot1 = 0;
  for (int i = 0; i < smoothing; i++) {
    pot1 += pot1values[i];
  }
  pot1 = pot1/smoothing;
  pot2 = analogRead(POT_2);
  pot3 = analogRead(POT_3);
  
  // Serial.print("Pot1: ");
  // Serial.println(pot1);
  // Serial.print("Pot2: ");
  // Serial.println(pot2);
  // Serial.print("Pot3: ");
  // Serial.println(pot3);

  btn1 = digitalRead(BTN_1);
  btn2 = digitalRead(BTN_2);
  // Serial.print("Btn1: ");
  // Serial.println(btn1);
  // Serial.print("Btn2: ");
  // Serial.println(btn2);
  btn3 = digitalRead(BTN_3);
  btn4 = digitalRead(BTN_4);
  btn5 = digitalRead(BTN_5);
  btn6 = digitalRead(BTN_6);

  //only passing as btn 5 -- we'll see if btn 6 works. . .
  if(btn5 == 0 || btn6 == 0) {
    btn5 = 0;
  }

  Serial.print("Btn 5: ");
  Serial.println(btn5);
  Serial.print("Btn 5: ");
  Serial.println(btn6);

  //Updating JSON
  UpdateJson("Pot1P33", pot1); //Output: 0-4095
  UpdateJson("Pot2P25", pot2); //Output: 0-4095
  UpdateJson("Pot3P26", pot3); //Output: 0-4095
  UpdateJson("Fret1P23", btn1); //Output: 0 or 1
  UpdateJson("Fret2P22", btn2); //Output: 0 or 1
  UpdateJson("Fret3P21", btn3); //Output: 0 or 1
  UpdateJson("Fret4P19", btn4); //Output: 0 or 1
  UpdateJson("Strum1P18and5", btn5); //Output: 0 or 1
  // UpdateJson("Strum1P5", btn6); //Output: 0 or 1

  //Sending
  serializeJson(doc, BTSerial);
  BTSerial.println();
  delay(100);
}