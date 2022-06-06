using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class WheelController : MonoBehaviour
{

    [SerializeField] WheelCollider zero;
    [SerializeField] WheelCollider one;
    [SerializeField] WheelCollider two;
    [SerializeField] WheelCollider three;
    [SerializeField] WheelCollider four;
    [SerializeField] WheelCollider five;
    [SerializeField] WheelCollider six;
    [SerializeField] WheelCollider seven;

    public double acceleration = 150;
    public double breakingForce = 300;
    public double maxTurn = 150;

    private double currentAccelerationRight = 0;
    private double currentAccelerationLeft = 0;
    private double currentBreakForce = 0;
    private bool forward = false, backward = false, right = false, left = false;
    double leftOutput = 0;
    double rightOutput = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
      if(Input.GetKey(KeyCode.Space))
          currentBreakForce = breakingForce;
      else
          currentBreakForce = 0;
      
      

      forward = Input.GetAxis("Vertical") > 0 ? true : false;
      backward = Input.GetAxis("Vertical") >= 0 ? false : true;

      right = Input.GetAxis("Horizontal") > 0 ? true : false;
      left = Input.GetAxis("Horizontal") >= 0 ? false : true;

      if(forward){
        if(right){
          leftOutput = 1.0;
          rightOutput = .25;
        }else if(left){
          leftOutput = .25;
          rightOutput = 1.0;
        }else{
          leftOutput = 1;
          rightOutput = 1;
        }
      }else if(backward){
        if(right){
          leftOutput = -1.0;
          rightOutput = -.25;
        }else if(left){
          leftOutput = -.25;
          rightOutput = -1.0;
        }else{
          leftOutput = -1;
          rightOutput = -1;
        }
      }else if((!forward && !backward) && (right || left)){
        if(right){
          leftOutput = 1;
          rightOutput = -1;
        }else if(left){
          leftOutput = -1;
          rightOutput = 1;
        }
      }else if((!forward && !backward) && (!right && !left)){
        leftOutput = 0;
        rightOutput = 0;
      }


        
        
    
      if(currentAccelerationLeft == 0 && currentAccelerationRight == 0){
        currentBreakForce = breakingForce;
      }else{
        currentBreakForce = 0;
      }
    
      currentAccelerationLeft = maxTurn * leftOutput;
      currentAccelerationRight = maxTurn * rightOutput;

      zero.motorTorque = (float) currentAccelerationRight;
      one.motorTorque = (float) currentAccelerationRight;
      two.motorTorque = (float) currentAccelerationRight;
      three.motorTorque = (float) currentAccelerationRight;
      four.motorTorque = (float) currentAccelerationLeft;
      five.motorTorque = (float) currentAccelerationLeft;
      six.motorTorque = (float) currentAccelerationLeft;
      seven.motorTorque = (float) currentAccelerationLeft;

      zero.brakeTorque = (float) currentBreakForce;
      one.brakeTorque = (float) currentBreakForce;
      two.brakeTorque = (float) currentBreakForce;
      three.brakeTorque = (float) currentBreakForce;
      four.brakeTorque = (float) currentBreakForce;
      five.brakeTorque = (float) currentBreakForce;
      six.brakeTorque = (float) currentBreakForce;
      seven.brakeTorque = (float) currentBreakForce;
        
    }

    /** Applys a Deadband */
  public double applyDeadband(double value, double deadband) {
    if (abs(value) > deadband) {
      if (value > 0.0) {
        return (value - deadband) / (1.0 - deadband);
      } else {
        return (value + deadband) / (1.0 - deadband);
      }
    } else {
      return 0.0;
    }
  }

  public double abs(double x){
      if(x>0){
          return x;
      }else if(x<0){
          return x * -1;
      }else if(x == 0){
          return x;
      }else{
          return 0;
      }
  }


}
