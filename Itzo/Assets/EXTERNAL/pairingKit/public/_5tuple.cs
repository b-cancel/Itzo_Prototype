﻿namespace pairingKit
{
    /// <summary>
    /// Description: public functions for 5 tuple pairing
    /// Programmer: Bryan Cancel
    /// Combine Sequence ((a,b),[(c,d),(e)]) -> z
    /// Reverse Sequence z
    /// </summary>

    /*
     * C# Integral Types
     * 
     * -------------------------using BYTES
     * sbyte	-128 to 127	Signed 8-bit integer
     * byte	    0 to 255	Unsigned 8-bit integer
     * COMBOS: (25_6)^2 = 65,536 [exactly what ushort can store]
     * 
     * using SZUDZIK: 
     *      (byte,byte) -> [ushort]
     *      (byte,byte) -> [ushort]
     *      ([ushort],[ushort]) -> [uint]
     *      ([uint],uint) -> [ulong]
     * 
     * -------------------------using SHORTS
     * short	-32,768 to 32,767	Signed 16-bit integer
     * ushort	0 to 65,535	Unsigned 16-bit integer
     * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
     * 
     * using SZUDZIK:
     *      (ushort,ushort) -> [uint]
     *      (ushort,ushort) -> [uint]
     *      ([uint],[uint]) -> [ulong]
     *      ([ulong],ulong) -> [BigInteger]           STOP         
     * 
     * -------------------------using INTS
     * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
     * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
     * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
     * 
     * using SZUDZIK:
     *      (uint,uint) -> [ulong]
     *      (uint,uint) -> [ulong]
     *      ([ulong],[ulong]) -> [BigInteger]           
     *      ([BigInteger],BigInteger) -> [BigInteger]           DONT     
     * 
     * -------------------------using LONGS
     * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
     * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
     * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
     * 
     * using SZUDZIK:
     *      (ulong,ulong) -> [BigInteger]
     *      (ulong,ulong) -> [BigInteger]
     *      ([BigInteger],[BigInteger]) -> [BigInteger]
     *      ([BigInteger],BigInteger) -> [BigInteger]           DONT
     */

    public static class _5tuple //1 type range [(byte/sbyte)]
    {
        #region (X,Y) -> Z

        //(sbyte/byte) [2]
        //[2]^5 = 32 possible combos

        #region byte [16]

        #region byte, byte [8]

        #region byte, byte, byte [4]

        #region byte, byte, byte, byte [2]

        //5th byte
        public static ulong combine(byte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(byte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte, byte, byte, sbyte [2]

        //5th byte
        public static ulong combine(byte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(byte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte, byte, sbyte [4]

        #region byte, byte, sbyte, byte [2]

        //5th byte
        public static ulong combine(byte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(byte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte, byte, sbyte, sbyte [2]

        //5th byte
        public static ulong combine(byte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(byte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region byte, sbyte [8]

        #region byte, sbyte, byte [4]

        #region byte, sbyte, byte, byte [2]

        //5th byte
        public static ulong combine(byte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(byte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte, sbyte, byte, sbyte [2]

        //5th byte
        public static ulong combine(byte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(byte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte, sbyte, sbyte [4]

        #region byte, sbyte, sbyte, byte [2]

        //5th byte
        public static ulong combine(byte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(byte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte, sbyte, sbyte, sbyte [2]

        //5th byte
        public static ulong combine(byte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(byte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region sbyte [16]

        #region sbyte byte [8]

        #region sbyte byte byte [4]

        #region sbyte byte byte byte [2]

        //5th byte
        public static ulong combine(sbyte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(sbyte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte byte sbyte [2]

        //5th byte
        public static ulong combine(sbyte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(sbyte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte byte sbyte [4]

        #region sbyte byte sbyte byte [2]

        //5th byte
        public static ulong combine(sbyte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(sbyte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte sbyte sbyte [2]

        //5th byte
        public static ulong combine(sbyte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(sbyte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region sbyte sbyte [8]

        #region sbyte sbyte byte [4]

        #region sbyte sbyte byte byte [2]

        //5th byte
        public static ulong combine(sbyte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(sbyte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte byte sbyte [2]

        //5th byte
        public static ulong combine(sbyte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(sbyte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte sbyte sbyte [4]

        #region sbyte sbyte sbyte byte [2]

        //5th byte
        public static ulong combine(sbyte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(sbyte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte sbyte sbyte [2]

        //5th byte
        public static ulong combine(sbyte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //5th sbyte
        public static ulong combine(sbyte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(v, w), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #region Z -> (X,Y)

        //((a,b),[(c,d),(e)])
        public static byte[] reverse(ulong z) //5 bytes... round to 8 bytes = 4 ushorts = 2 uints = 1 ulong
        {
            uint[] P1_P2 = _2tuple.reverse(z);
            ushort[] vw = _2tuple.reverse(P1_P2[0]); //v,w
            ushort[] XYz = _2tuple.reverse(P1_P2[1]); //[(x,y),z]
            byte[] xy = _2tuple.reverse(XYz[0]);
            return new byte[] { (byte)vw[0], (byte)vw[1], xy[0], xy[1], (byte)XYz[1] };
        }

        #endregion
    }
}