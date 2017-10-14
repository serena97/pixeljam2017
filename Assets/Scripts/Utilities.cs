using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities {
    public static bool Offscreen(Vector2 position) {
        if (position.x < -10 || position.x > 10)
            return true;
        if (position.y < -10 || position.y > 10)
            return true;
        return false;
    }
}
