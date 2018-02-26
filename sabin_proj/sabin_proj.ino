
String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";


int led1Pin = 11;
int led2Pin = 12;
boolean isConnected = false;

void setup() {
 Serial.begin(9600);
  pinMode(led1Pin,OUTPUT);
   pinMode(led2Pin,OUTPUT);
}



void loop() {

if(stringComplete)
{
  stringComplete = false;
  getCommand();
  
  
  if(commandString.equals("STOP"))
  {
    turnLedOff(led1Pin);
   
   turnLedOff(led2Pin);
  }
 
  else if(commandString.equals("LED1"))
  {
    boolean LedState = getLedState();
    if(LedState == true)
    {
      turnLedOn(led1Pin);
    }else
    {
      turnLedOff(led1Pin);
    }   
  }
  else if(commandString.equals("LED2"))
  {
    boolean LedState = getLedState();
    if(LedState == true)
    {
      turnLedOn(led2Pin);
    }else
    {
      turnLedOff(led2Pin);
    }   
  }
  
  inputString = "";
}

}
 
boolean getLedState()
{
  boolean state = false;
  if(inputString.substring(5,7).equals("ON"))
  {
    state = true;
  }else
  {
    state = false;
  }
  return state;
}

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,5);
  }
}

void turnLedOn(int pin)
{
  digitalWrite(pin,HIGH);
}

void turnLedOff(int pin)
{
  digitalWrite(pin,LOW);
}

 
void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}

