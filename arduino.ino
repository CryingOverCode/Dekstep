#include <SoftwareSerial.h>
SoftwareSerial BT(1, 0);

#define echoPin 2 
#define trigPin 3

long duration; 
int distance; 
int prev;
bool isEnter = false;
bool inRoom = false;
bool first = true;


void setup() {
  pinMode(trigPin, OUTPUT); 
  pinMode(echoPin, INPUT); 
  BT.begin(9600); // // Serial Communication is starting with 9600 of baudrate speed
  BT.println("Ultrasonic Sensor HC-SR04 Test"); // print some text in Serial Monitor
  BT.println("with Arduino UNO R3");

}
void loop() {

  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  // Sets the trigPin HIGH (ACTIVE) for 10 microseconds
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(echoPin, HIGH);
  // Calculating the distance
  distance = duration * 0.034 / 2; // Speed of sound wave divided by 2 (go and back)
  if (first){
   prev = distance;
   first = false;
  }
  if (distance < prev - 10)
  {
    inRoom = !inRoom;
    isEnter = true;
  }

  prev = distance;
  // Displays the distance on the Serial Monitor
  //Serial.print(isEnter);
  //Serial.print(distance);
  //Serial.println(" cm");
}
