//
//  LookbackAppController.m
//  lookback_unity_ios_plugin
//
//  Created by Andrew Lee on 2015-06-10.
//  Copyright (C) 2015 INVIVO Communications Inc.
//
//
#import <Lookback/Lookback.h>
#import "UnityAppController.h"

extern UIViewController* UnityGetGLViewController();

@interface LookbackAppController : UnityAppController

@end

@implementation LookbackAppController

- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    [super application:application didFinishLaunchingWithOptions:launchOptions];
    
    return YES;
}

@end

IMPL_APP_CONTROLLER_SUBCLASS(LookbackAppController)

extern "C" {
    void InitializeLookback(const char* sdkToken) {
        if(sdkToken == NULL) {
            NSLog(@"InitializeLookback() - sdkToken is NULL");
            return;
        }
        
        [Lookback setupWithAppToken:[NSString stringWithUTF8String:sdkToken]];
        [Lookback sharedLookback].shakeToRecord = YES;
        [Lookback sharedLookback].feedbackBubbleVisible = YES;
    }
    
    void SetShakeToRecord(bool shakeToRecord) {
        [Lookback sharedLookback].shakeToRecord = shakeToRecord;
    }

    void SetFeedbackBubbleVisible(bool feedbackBubbleVisible) {
        [Lookback sharedLookback].feedbackBubbleVisible = feedbackBubbleVisible;
    }
    
    void SetFeedbackBubbleForegroundColour(float r, float g, float b, float a) {
        [[Lookback sharedLookback] setFeedbackBubbleForegroundColor:[UIColor colorWithRed:r/255.0f green:g/255.0f blue:b/255.0f alpha:a/255.0f]];
    }
    
    void SetFeedbackBubbleBackgroundColour(float r, float g, float b, float a) {
        [[Lookback sharedLookback] setFeedbackBubbleBackgroundColor:[UIColor colorWithRed:r/255.0f green:g/255.0f blue:b/255.0f alpha:a/255.0f]];
    }

    void EnteredView(const char* viewIdentifier) {
        if(viewIdentifier == NULL) {
            NSLog(@"EnteredView() - viewIdentifier is NULL");
            return;
        }
        [[Lookback sharedLookback] enteredView:[NSString stringWithUTF8String:viewIdentifier]];
    }
    
    void ExitedView(const char* viewIdentifier) {
        if(viewIdentifier == NULL) {
            NSLog(@"ExitedView() - viewIdentifier is NULL");
            return;
        }
        [[Lookback sharedLookback] exitedView:[NSString stringWithUTF8String:viewIdentifier]];
    }
    
    bool ShakeToRecord() {
        return [Lookback sharedLookback].shakeToRecord;
    }
    
    bool FeedbackBubbleVisible() {
        return [Lookback sharedLookback].feedbackBubbleVisible;
    }
}
