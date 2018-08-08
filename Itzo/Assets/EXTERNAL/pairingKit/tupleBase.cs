using System;

namespace pairingKit
{
    /// <summary>
    /// Description: pairingKit using the Cantor Pairing & Szudzik Pairing Functions
    /// Programmer: Bryan Cancel
    /// Reason For Existance: 
    ///     -pairing functions are great but they have their limits and I would like to clearly communicate them
    ///     -its only a bijection from NxN -> N (Natural Numbers, 0 included)
    ///         -I would like to also have a bijection from 
    ///             -ZxZ -> Z (with a bijection from N to Z)
    ///             -QxQ -> Q (with a bijection from 2 N to 1 Q)
    ///     -C# types must be used carefully given the above
    /// Sources:
    ///     https://stackoverflow.com/questions/919612/mapping-two-integers-to-one-in-a-unique-and-deterministic-way [Cantor or Szudzik]
    ///     http://szudzik.com/ElegantPairing.pdf [Szudzik]
    /// Assumptions: 
    ///     -you might want to test Cantor or Szudzik Pairing
    ///     -Doing Math with types that hold less data is faster 
    ///     -conversion between types takes up time BUT the speed you gain from using types that hold less data make this extra time negligible
    ///     -the most effective math is between 2 pairs of the same type (since conversions also have some cost)    
    ///     -you might want to pair up 2 variables of all types [(byte/sbyte)|(ushort/short)|(uint/int)|(ulong/long)]
    ///     -you do not want to use BigInteger
    /// </summary>

    public class tupleBase {

        #region pairingFunctions

        #region Cantor Pairing

        /*
         * C# Integral Types
         * 
         * -------------------------using BYTES
         * sbyte	-128 to 127	Signed 8-bit integer
         * byte	    0 to 255	Unsigned 8-bit integer
         * COMBOS: (25_6)^2 = 65,536 [exactly what ushort can store]
         * 
         * CANTOR PAIR MAX: (using largest byte)
         *      cantor(255,255) = ((((255 + 255) * (255 + 255 + 1)) / 2) + 255) 
         *      = ((((2*255) * ((2*255) + 1)) / 2) + 255) = [130,560] (REQUIRES uint)
         * 
         * -------------------------using SHORTS
         * short	-32,768 to 32,767	Signed 16-bit integer
         * ushort	0 to 65,535	Unsigned 16-bit integer
         * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
         * 
         * CANTOR PAIR MAX: (using largest ushort)
         *      cantor([65,535],[65,535]) = (((([65,535] + [65,535]) * ([65,535] + [65,535] + 1)) / 2) + [65,535]) 
         *      = ((((2*[65,535]) * ((2*[65,535]) + 1)) / 2) + [65,535]) = [8,589,803,520] (REQUIRES ulong)
         * 
         * -------------------------using INTS
         * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
         * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
         * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
         * 
         * CANTOR PAIR MAX: (using largest uint)
         *      cantor([4,294,967,295],[4,294,967,295]) 
         *      = (((([4,294,967,295] + [4,294,967,295]) * ([4,294,967,295] + [4,294,967,295] + 1)) / 2) + [4,294,967,295]) 
         *      = ((((2*[4,294,967,295]) * ((2*[4,294,967,295]) + 1)) / 2) + [4,294,967,295])
         *      = [36,893,488,138,829,168,640] (REQUIRES larger than ulong -OR- limitation)
         *      LIMITED SIZE -> LIMITED CANTOR PAIR MAX (just smaller than ulong)
         *      3037000499 -> 18,446,744,067,926,499,000 [smaller than ulong]
         *      3037000500 -> 18,446,744,080,074,501,000 [larger than ulong]
         * 
         * -------------------------using LONGS
         * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
         * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
         * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [maybe Big Integer]
         * 
         * CANTOR PAIR MAX: (using largest ulong)
         *      cantor([18,446,744,073,709,551,615],[18,446,744,073,709,551,615]) 
         *      = (((([18,446,744,073,709,551,615] + [18,446,744,073,709,551,615]) * ([18,446,744,073,709,551,615] + [18,446,744,073,709,551,615] + 1)) / 2) + [18,446,744,073,709,551,615]) 
         *      = ((((2*[18,446,744,073,709,551,615]) * ((2*[18,446,744,073,709,551,615]) + 1)) / 2) + [18,446,744,073,709,551,615])
         *      = [680,564,733,841,876,926,889,855,726,716,117,319,680] (REQUIRES larger than ulong -OR- limitation)
         *      LIMITATION would be pointless since it would cover the same numbers as ints and uints
         */

        #region For 8 Bit Integers

        //-----using BYTE

        internal static uint byteCantor2tupleCombine(byte x, byte y)
        {
            return (uint)((((x + y) * (x + y + 1)) / 2) + y);
        }

        internal static byte[] byteCantor2tupleReverse(uint z) //this number will be POSITIVE
        {
            //Assuming z is uint.MAXVALUE -> max of 185363.80005 (we don't need decimals)
            //ushort w = (ushort)Math.Sqrt((8 * z) + 1); //this number will be POSITIVE [PLACE INTO FUNC BELOW]
            //Assuming largest value 185363.80005 -> max of 92681 (ushort is too small) (use int)
            ushort W = (ushort)Math.Floor((double)(((Math.Sqrt((8 * z) + 1)) - 1) / 2)); //this number wILL be POSITIVE [if w >= 1 (which is always true)] (returns an integer)
            //Assuming largest vlaue 92681 -> 4,294,930,221 (ushort is too small) (use int)
            ushort T = (ushort)(((W * W) + W) / 2);

            byte y = (byte)(z - T);
            byte x = (byte)(W - y);

            return new byte[] { x, y };
        }

        //-----using SBYTE (using BYTE functions with slight adjustments)

        internal static uint sbyteCantor2tupleCombine(sbyte x, sbyte y)
        {
            return byteCantor2tupleCombine(tupleBase.sbyteToByte(x), tupleBase.sbyteToByte(y));
        }

        internal static sbyte[] sbyteCantor2tupleReverse(uint z)
        {
            byte[] byteRev = byteCantor2tupleReverse(z);
            return new sbyte[] { tupleBase.byteToSbyte(byteRev[0]), tupleBase.byteToSbyte(byteRev[1]) };
        }

        #endregion

        #region For 16,32,64 [Szudik is Faster]

        //NOTE: testing with sbytes using only unity and visual studios running in my pluged in laptop
        //I did performance testing using "stopwatch" from "using System.Diagnostics;"
        //---
        //Cantor takes [34] Ticks for both (pairing + reverse) commands
        //(pairing takes [3] Ticks) (reverse takes [31] Ticks) [when tested individually]
        //31 + 3 = 34 == 34
        //---
        //Szudik takes a solid [31] Ticks for both (pairing + reverse) commands
        //(pairing takes [4] Ticks) (reverse takes [29] Ticks) [when tested individually]
        //29 + 4 = 33 != 31

        //Because of...
        //(1) the very slight difference in performace between Cantor and Szudzik
        //(2) and the fact that Szudzik takes up less space than Cantor
        //[*] It makes no sense to  continue to implement Functions for Cantor

        #region For 16 Bit Integers

        //-----using SHORT

        //-----using USHORT

        #endregion

        #region For 32 Bit Integers

        //-----using INT

        //-----using UINT

        #endregion

        #region For 64 Bit Integers

        //-----using LONG

        //-----using ULONG

        #endregion

        #endregion

        #endregion

        #region Szudzik Pairing

        /*
         * C# Integral Types
         * 
         * -------------------------using BYTES
         * sbyte	-128 to 127	Signed 8-bit integer
         * byte	    0 to 255	Unsigned 8-bit integer
         * COMBOS: (25_6)^2 = 65,536 [exactly what ushort can store]
         * 
         * SZUDZIK PAIR MAX: (25_6)^2 = 65,536 [exactly what ushort can store]
         * 
         * -------------------------using SHORTS
         * short	-32,768 to 32,767	Signed 16-bit integer
         * ushort	0 to 65,535	Unsigned 16-bit integer
         * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
         * 
         * SZUDZIK PAIR MAX: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
         * 
         * -------------------------using INTS
         * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
         * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
         * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
         * 
         * SZUDZIK PAIR MAX: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
         * 
         * -------------------------using LONGS
         * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
         * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
         * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
         * 
         * SZUDZIK PAIR MAX: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
         */

        #region For 8 Bit Integers

        //-----using BYTE

        internal static ushort byteSzudzik2tupleCombine(byte x, byte y)
        {
            if (x != Math.Max(x, y))
                return (ushort)((y * y) + x);
            else
                return (ushort)((x * x) + x + y);
        }

        internal static byte[] byteSzudzik2tupleReverse(ushort z) //this number WILL be positive
        {
            //Assuming z is ushort.MAXVALUE -> max of 255 (use byte)
            byte zSpecial1 = (byte)Math.Floor(Math.Sqrt(z)); //this number WILL be positive (returns integer)
            //Assuming largest values -> max of 510 (byte is too small) (use short)
            ushort zSpecial2 = (ushort)(z - (zSpecial1 * zSpecial1)); //this number WILL be positive (returns integer)

            if (zSpecial2 < zSpecial1)
                return new byte[] { (byte)zSpecial2, (byte)zSpecial1 };
            else
                return new byte[] { (byte)zSpecial1, (byte)(zSpecial2 - zSpecial1) };
        }

        //-----using SBYTE (using BYTE functions with slight adjustments)

        internal static ushort sbyteSzudzik2tupleCombine(sbyte x, sbyte y)
        {
            return byteSzudzik2tupleCombine(tupleBase.sbyteToByte(x), tupleBase.sbyteToByte(y));
        }

        internal static sbyte[] sbyteSzudzik2tupleReverse(ushort z)
        {
            byte[] byteRev = byteSzudzik2tupleReverse(z);
            return new sbyte[] { tupleBase.byteToSbyte(byteRev[0]), tupleBase.byteToSbyte(byteRev[1]) };
        }

        #endregion

        #region For 16 Bit Integers

        //-----using USHORT

        internal static uint ushortSzudzik2tupleCombine(ushort x, ushort y)
        {
            if (x != Math.Max(x, y))
                return (uint)((y * y) + x);
            else
                return (uint)((x * x) + x + y);
        }

        internal static ushort[] ushortSzudzik2tupleReverse(uint z) //this number WILL be positive
        {
            ushort zSpecial1 = (ushort)Math.Floor(Math.Sqrt(z)); //this number WILL be positive (returns integer)
            uint zSpecial2 = (uint)(z - (zSpecial1 * zSpecial1)); //this number WILL be positive (returns integer)

            if (zSpecial2 < zSpecial1)
                return new ushort[] { (ushort)zSpecial2, (ushort)zSpecial1 };
            else
                return new ushort[] { (ushort)zSpecial1, (ushort)(zSpecial2 - zSpecial1) };
        }

        //-----using SHORT (using USHORT functions with slight adjustments)

        internal static uint shortSzudzik2tupleCombine(short x, short y)
        {
            return ushortSzudzik2tupleCombine(tupleBase.shortToUshort(x), tupleBase.shortToUshort(y));
        }

        internal static short[] shortSzudzik2tupleReverse(uint z)
        {
            ushort[] ushortRev = ushortSzudzik2tupleReverse(z);
            return new short[] { tupleBase.ushortToShort(ushortRev[0]), tupleBase.ushortToShort(ushortRev[1]) };
        }

        #endregion

        #region For 32 Bit Integers

        //-----using USHORT

        internal static ulong uintSzudzik2tupleCombine(uint x, uint y)
        {
            if (x != Math.Max(x, y))
                return (ulong)((y * y) + x);
            else
                return (ulong)((x * x) + x + y);
        }

        internal static uint[] uintSzudzik2tupleReverse(ulong z) //this number WILL be positive
        {
            uint zSpecial1 = (uint)Math.Floor(Math.Sqrt(z)); //this number WILL be positive (returns integer)
            ulong zSpecial2 = (ulong)(z - (zSpecial1 * zSpecial1)); //this number WILL be positive (returns integer)

            if (zSpecial2 < zSpecial1)
                return new uint[] { (uint)zSpecial2, (uint)zSpecial1 };
            else
                return new uint[] { (uint)zSpecial1, (uint)(zSpecial2 - zSpecial1) };
        }

        //-----using SHORT (using USHORT functions with slight adjustments)

        internal static ulong intSzudzik2tupleCombine(int x, int y)
        {
            return uintSzudzik2tupleCombine(tupleBase.intToUint(x), tupleBase.intToUint(y));
        }

        internal static int[] intSzudzik2tupleReverse(ulong z)
        {
            uint[] uintRev = uintSzudzik2tupleReverse(z);
            return new int[] { tupleBase.uintToInt(uintRev[0]), tupleBase.uintToInt(uintRev[1]) };
        }

        #endregion

        #region For 64 Bit Integers [requires BigInteger]

        //-----using ULONG

        //-----using LONG

        #endregion

        #endregion

        #endregion

        #region bijections

        //-------------------------For 8 Bit Integers

        public static sbyte byteToSbyte(byte b) //unsigned -> signed
        {
            return (sbyte)(((sbyte)(b - (127))) - (sbyte)1); //sbyte.MaxValue
        }

        public static byte sbyteToByte(sbyte sB) //signed -> unsigned
        {
            return (byte)(((byte)(sB + (127))) + (byte)1); //sbyte.MaxValue
        }

        //-------------------------For 16 Bit Integers

        public static short ushortToShort(ushort uS) //unsigned -> signed
        {
            return (short)(((short)(uS - (32767))) - (short)1); //short.MaxValue
        }

        public static ushort shortToUshort(short s) //signed -> unsigned
        {
            return (ushort)(((ushort)(s + (32767))) + (ushort)1); //short.MaxValue
        }

        //-------------------------For 32 Bit Integers

        public static int uintToInt(uint uI) //unsigned -> signed
        {
            return (int)(((int)(uI - (2147483647))) - (int)1); //int.MaxValue
        }

        public static uint intToUint(int i) //signed -> unsigned
        {
            return (uint)(((uint)(i + (2147483647))) + (uint)1); //int.MaxValue
        }

        //-------------------------For 64 Bit Integers

        public static long ulongToLong(ulong uL) //unsigned -> signed
        {
            return (long)(((long)(uL - (9223372036854775807))) - (long)1); //long.MaxValue
        }

        public static ulong longToUlong(long l) //signed -> unsigned
        {
            return (ulong)(((ulong)(l + (9223372036854775807))) + (ulong)1); //long.MaxValue
        }

        #endregion
    }
}