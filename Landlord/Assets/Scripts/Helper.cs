using System.Collections;
using System.Collections.Generic;
using System;
public static class Helper
{
    public static int roundToTen(double n) {
        return (int)Math.Round((int)n/10d,0) * 10;
    }

    
}