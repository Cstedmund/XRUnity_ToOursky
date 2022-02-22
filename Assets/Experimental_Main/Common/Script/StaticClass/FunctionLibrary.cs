using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FunctionLibrary
{
    public enum CurrentDevice {
        iPhone,
        iPad,
        Android,
        OtherDevice
    }

    public static CurrentDevice GetCurrentDevice() {
#if UNITY_IOS
        var identifier = SystemInfo.deviceModel;
        if (identifier.StartsWith("iPhone")) {
            // iPhone logic
            return CurrentDevice.iPhone;
        } else if (identifier.StartsWith("iPad")) {
            // iPad logic
            return CurrentDevice.iPad;
        }
#endif

#if UNITY_ANDROID
        return CurrentDevice.Android;
#endif
        return CurrentDevice.OtherDevice;
    }

    public enum Orientation {
        Portrait,
        Landscape
    }

    public static void SetDeviceOrientation(Orientation orientation, bool autoRotate) {
        if (autoRotate) {
            Screen.orientation = ScreenOrientation.AutoRotation;
        } else {
            switch (orientation) {
                case Orientation.Portrait:
                    Screen.orientation = ScreenOrientation.Portrait;
                    break;
                case Orientation.Landscape:
                    Screen.orientation = ScreenOrientation.Landscape;
                    break;
                default:
                    break;
            }
        }
    }

}
