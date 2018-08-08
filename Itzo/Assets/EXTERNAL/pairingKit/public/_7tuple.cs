﻿namespace pairingKit
{
    /// <summary>
    /// Description: public functions for 6 tuple pairing
    /// Programmer: Bryan Cancel
    /// Combine Sequence ([(a,b),(c,d)],[(e,f),g]) -> z
    /// Reverse Sequence 
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
     *      (byte,byte) -> [ushort] -> (AB)
     *      (byte,byte) -> [ushort] -> (CD)
     *      ([ushort],[ushort]) -> [uint] -> [(AB),(CD)]
     *      (byte,byte) -> [ushort] (EF)
     *      ([ushort],ushort) -> [uint] [(EF),(G)]
     *      ([uint],[uint]) -> [ulong] ([(AB),(CD)],[(EF),(G)])
     * 
     * -------------------------using SHORTS
     * short	-32,768 to 32,767	Signed 16-bit integer
     * ushort	0 to 65,535	Unsigned 16-bit integer
     * COMBOS: (65,53_6)^2 = 4,294,967,296 [exactly what uint can store]
     * 
     * using SZUDZIK:
     *      (ushort,ushort) -> [uint] -> (AB)
     *      (ushort,ushort) -> [uint] -> (CD)
     *      ([uint],[uint]) -> [ulong] -> [(AB),(CD)]
     *      (ushort,ushort) -> [uint] -> (EF)
     *      ([uint],uint) -> [ulong] -> [(EF),(G)]
     *      ([ulong],[ulong]) -> [BigInteger] -> ([(AB),(CD)],[(EF),(G)])          STOP
     * 
     * -------------------------using INTS
     * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
     * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
     * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
     * 
     * using SZUDZIK:
     *      (uint,uint) -> [ulong] (AB)
     *      (uint,uint) -> [ulong] (CD)
     *      ([ulong],[ulong]) -> [BigInteger] [(AB),(CD)]
     *      (uint,uint) -> [ulong] (EF)
     *      ([ulong],ulong) -> [BigInteger] [(EF),(G)]
     *      ([BigInteger],[BigInteger]) -> [BigInteger] ([(AB),(CD)],[(EF),(G)])            DONT
     * 
     * -------------------------using LONGS
     * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
     * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
     * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
     * 
     * using SZUDZIK:
     *      (ulong,ulong) -> [BigInteger] (AB)
     *      (ulong,ulong) -> [BigInteger] (CD)
     *      ([BigInteger],[BigInteger]) -> [BigInteger] [(AB),(CD)]
     *      (ulong,ulong) -> [BigInteger] (EF)
     *      ([BigInteger],BigInteger) -> [BigInteger] [(EF),(G)]
     *      ([BigInteger],[BigInteger]) -> [BigInteger] ([(AB),(CD)],[(EF),(G)])            DONT
     */

    public static class _7tuple //1 type range [(byte/sbyte)]
    {
        #region (X,Y) -> Z

        //(sbyte/byte) [2]
        //[2]^7 = 128 possible combos

        #region byte

        #region byte byte

        #region byte byte byte [16]

        #region byte byte byte byte [8]

        #region byte byte byte byte byte [4]

        #region byte byte byte byte byte byte [2]

        //last byte ([(a,b),(c,d)],[(e,f),g])
        public static ulong combine(byte t, byte u, byte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t,u),_2tuple.combine(v,w)) , _2tuple.combine(_2tuple.combine(x,y),z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, byte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte byte byte byte byte sbyte [2]

        //last byte
        public static ulong combine(byte t, byte u, byte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, byte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte byte byte byte sbyte [4]

        #region byte byte byte byte sbyte byte [2]

        //last byte
        public static ulong combine(byte t, byte u, byte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, byte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte byte byte byte sbyte sbyte [2]

        //last byte
        public static ulong combine(byte t, byte u, byte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, byte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region byte byte byte sbyte [8]

        #region byte byte byte sbyte byte [4]

        #region byte byte byte sbyte byte byte [2]

        //last byte
        public static ulong combine(byte t, byte u, byte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, byte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte byte byte sbyte byte sbyte [2]

        //last byte
        public static ulong combine(byte t, byte u, byte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, byte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte byte byte sbyte sbyte [4]

        #region byte byte byte sbyte sbyte byte [2]

        //last byte
        public static ulong combine(byte t, byte u, byte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, byte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte byte byte sbyte sbyte sbyte [2]

        //last byte
        public static ulong combine(byte t, byte u, byte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, byte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region byte byte sbyte [16]

        #region byte byte sbyte byte [8]

        #region byte byte sbyte byte byte [4]

        #region byte byte sbyte byte byte byte [2]

        //last byte
        public static ulong combine(byte t, byte u, sbyte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, sbyte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte byte sbyte byte byte sbyte [2]

        //last byte
        public static ulong combine(byte t, byte u, sbyte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, sbyte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte byte sbyte byte sbyte [4]

        #region byte byte sbyte byte sbyte byte [2]

        //last byte
        public static ulong combine(byte t, byte u, sbyte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, sbyte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte byte sbyte byte sbyte sbyte [2]

        //last byte
        public static ulong combine(byte t, byte u, sbyte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, sbyte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region byte byte sbyte sbyte [8]

        #region byte byte sbyte sbyte byte [4]

        #region byte byte sbyte sbyte byte byte [2]

        //last byte
        public static ulong combine(byte t, byte u, sbyte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, sbyte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte byte sbyte sbyte byte sbyte [2]

        //last byte
        public static ulong combine(byte t, byte u, sbyte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, sbyte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte byte sbyte sbyte sbyte [4]

        #region byte byte sbyte sbyte sbyte byte [2]

        //last byte
        public static ulong combine(byte t, byte u, sbyte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, sbyte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte byte sbyte sbyte sbyte sbyte [2]

        //last byte
        public static ulong combine(byte t, byte u, sbyte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, byte u, sbyte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #region byte sbyte

        #region byte sbyte byte [16]

        #region byte sbyte byte byte [8]

        #region byte sbyte byte byte byte [4]

        #region byte sbyte byte byte byte byte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, byte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, byte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte sbyte byte byte byte sbyte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, byte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, byte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte sbyte byte byte sbyte [4]

        #region byte sbyte byte byte sbyte byte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, byte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, byte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte sbyte byte byte sbyte sbyte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, byte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, byte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region byte sbyte byte sbyte [8]

        #region byte sbyte byte sbyte byte [4]

        #region byte sbyte byte sbyte byte byte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, byte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, byte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte sbyte byte sbyte byte sbyte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, byte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, byte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte sbyte byte sbyte sbyte [4]

        #region byte sbyte byte sbyte sbyte byte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, byte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, byte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte sbyte byte sbyte sbyte sbyte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, byte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, byte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region byte sbyte sbyte [16]

        #region byte sbyte sbyte byte [8]

        #region byte sbyte sbyte byte byte [4]

        #region byte sbyte sbyte byte byte byte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, sbyte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, sbyte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte sbyte sbyte byte byte sbyte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, sbyte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, sbyte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte sbyte sbyte byte sbyte [4]

        #region byte sbyte sbyte byte sbyte byte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, sbyte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, sbyte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte sbyte sbyte byte sbyte sbyte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, sbyte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, sbyte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region byte sbyte sbyte sbyte [8]

        #region byte sbyte sbyte sbyte byte [4]

        #region byte sbyte sbyte sbyte byte byte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, sbyte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, sbyte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte sbyte sbyte sbyte byte sbyte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, sbyte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, sbyte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region byte sbyte sbyte sbyte sbyte [4]

        #region byte sbyte sbyte sbyte sbyte byte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, sbyte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, sbyte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region byte sbyte sbyte sbyte sbyte sbyte [2]

        //last byte
        public static ulong combine(byte t, sbyte u, sbyte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(byte t, sbyte u, sbyte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #region sbyte

        #region sbyte byte

        #region sbyte byte byte [16]

        #region sbyte byte byte byte [8]

        #region sbyte byte byte byte byte [4]

        #region sbyte byte byte byte byte byte [2]

        //last byte ([(a,b),(c,d)],[e,f])
        public static ulong combine(sbyte t, byte u, byte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, byte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte byte byte byte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, byte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, byte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte byte byte byte sbyte [4]

        #region sbyte byte byte byte sbyte byte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, byte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, byte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte byte byte sbyte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, byte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, byte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region sbyte byte byte sbyte [8]

        #region sbyte byte byte sbyte byte [4]

        #region sbyte byte byte sbyte byte byte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, byte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, byte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte byte sbyte byte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, byte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, byte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte byte byte sbyte sbyte [4]

        #region sbyte byte byte sbyte sbyte byte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, byte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, byte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte byte sbyte sbyte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, byte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, byte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region sbyte byte sbyte [16]

        #region sbyte byte sbyte byte [8]

        #region sbyte byte sbyte byte byte [4]

        #region sbyte byte sbyte byte byte byte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, sbyte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, sbyte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte sbyte byte byte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, sbyte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, sbyte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte byte sbyte byte sbyte [4]

        #region sbyte byte sbyte byte sbyte byte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, sbyte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, sbyte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte sbyte byte sbyte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, sbyte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, sbyte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region sbyte byte sbyte sbyte [8]

        #region sbyte byte sbyte sbyte byte [4]

        #region sbyte byte sbyte sbyte byte byte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, sbyte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, sbyte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte sbyte sbyte byte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, sbyte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, sbyte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte byte sbyte sbyte sbyte [4]

        #region sbyte byte sbyte sbyte sbyte byte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, sbyte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, sbyte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte byte sbyte sbyte sbyte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, byte u, sbyte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, byte u, sbyte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #region sbyte sbyte

        #region sbyte sbyte byte [16]

        #region sbyte sbyte byte byte [8]

        #region sbyte sbyte byte byte byte [4]

        #region sbyte sbyte byte byte byte byte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, byte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, byte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte byte byte byte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, byte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, byte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte sbyte byte byte sbyte [4]

        #region sbyte sbyte byte byte sbyte byte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, byte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, byte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte byte byte sbyte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, byte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, byte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region sbyte sbyte byte sbyte [8]

        #region sbyte sbyte byte sbyte byte [4]

        #region sbyte sbyte byte sbyte byte byte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, byte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, byte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte byte sbyte byte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, byte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, byte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte sbyte byte sbyte sbyte [4]

        #region sbyte sbyte byte sbyte sbyte byte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, byte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, byte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte byte sbyte sbyte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, byte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, byte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region sbyte sbyte sbyte [16]

        #region sbyte sbyte sbyte byte [8]

        #region sbyte sbyte sbyte byte byte [4]

        #region sbyte sbyte sbyte byte byte byte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, sbyte v, byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, sbyte v, byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte sbyte byte byte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, sbyte v, byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, sbyte v, byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte sbyte sbyte byte sbyte [4]

        #region sbyte sbyte sbyte byte sbyte byte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, sbyte v, byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, sbyte v, byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte sbyte byte sbyte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, sbyte v, byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, sbyte v, byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #region sbyte sbyte sbyte sbyte [8]

        #region sbyte sbyte sbyte sbyte byte [4]

        #region sbyte sbyte sbyte sbyte byte byte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, sbyte v, sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, sbyte v, sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte sbyte sbyte byte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, sbyte v, sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, sbyte v, sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #region sbyte sbyte sbyte sbyte sbyte [4]

        #region sbyte sbyte sbyte sbyte sbyte byte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, sbyte v, sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, sbyte v, sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #region sbyte sbyte sbyte sbyte sbyte sbyte [2]

        //last byte
        public static ulong combine(sbyte t, sbyte u, sbyte v, sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        //last sbyte
        public static ulong combine(sbyte t, sbyte u, sbyte v, sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(_2tuple.combine(t, u), _2tuple.combine(v, w)), _2tuple.combine(_2tuple.combine(x, y), z));
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #region Z -> (X,Y)

        //([(a,b),(c,d)],[(e,f),g])
        public static byte[] reverse(ulong z) //7 bytes... round to 8 bytes = 4 ushorts = 2 uints = 1 ulong
        {
            uint[] P1_P2 = _2tuple.reverse(z); //[ABCD],[EFG]
            //[ABCD]
            ushort[] AB_CD = _2tuple.reverse(P1_P2[0]); //[ABCD]
            byte[] ab = _2tuple.reverse(AB_CD[0]);
            byte[] cd = _2tuple.reverse(AB_CD[1]);
            //[EFG]
            ushort[] EFg = _2tuple.reverse(P1_P2[1]); //[EFG]
            byte[] ef = _2tuple.reverse(EFg[0]);
            return new byte[] { ab[0], ab[1], cd[0], cd[1], (byte)ef[0], (byte)ef[1] , (byte)EFg[1]};
        }

        #endregion
    }
}