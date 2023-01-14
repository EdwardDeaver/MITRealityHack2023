#include <BluetoothSerial.h>
#include <ArduinoJson.h>
BluetoothSerial BTSerial;
StaticJsonDocument<800> doc;
const int trigPin = 5;
const int echoPin = 18;

//define sound speed in cm/uS
#define SOUND_SPEED 0.034
#define CM_TO_INCH 0.393701

long duration;
float distanceCm;
float distanceInch;
// the setup routine runs on start and once when you press reset:
void setup() {


  String name = "Jacobs-ESP32";
  Serial.begin(9600);
  // initialize serial communication at 9600 bits per second:
  BTSerial.begin(name);
  Serial.println("Bluetooth Started... Called: " + name);
  doc["status"] = "running";
  doc["name"] = name;

  pinMode(trigPin, OUTPUT); // Sets the trigPin as an Output
  pinMode(echoPin, INPUT); // Sets the echoPin as an Input
}
void UpdateJson(String field, int value){
  doc[field] = value; 
}
float DistanceData(){
    // Clears the trigPin
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  // Sets the trigPin on HIGH state for 10 micro seconds
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  
  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(echoPin, HIGH);
  
  // Calculate the distance
  distanceCm = duration * SOUND_SPEED/2;
  
  // Convert to inches
  distanceInch = distanceCm * CM_TO_INCH;
  
  return distanceCm; 
}

// the loop routine runs over and over again forever:
void loop() {

  UpdateJson("UltrasonicP18", DistanceData());
  Update("ButtonSensor", ButtonDataGrabber()); 
  serializeJson(doc, BTSerial);
  delay(100);
 

}
