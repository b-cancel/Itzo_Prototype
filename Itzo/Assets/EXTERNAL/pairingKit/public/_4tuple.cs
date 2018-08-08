namespace pairingKit
{
    /// <summary>
    /// Description: public functions for 4 tuple pairing
    /// Programmer: Bryan Cancel
    /// Combine Sequence [(a,b),(c,d)] -> z
    /// Reverse Sequence z -> [(AB),(CD)] => (AB) -> (a,b) & (CD) -> (c,d)
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
     * 
     * -------------------------using INTS
     * int	    -2,147,483,648 to 2,147,483,647	Signed 32-bit integer
     * uint	    0 to 4,294,967,295	Unsigned 32-bit integer
     * COMBOS: (4,294,967,29_6)^2 = 18,446,744,073,709,551,616 [exactly what ulong can store]
     * 
     * using SZUDZIK:
     *      (uint,uint) -> [ulong]
     *      (uint,uint) -> [ulong]
     *      ([ulong],[ulong]) -> [BigInteger]           STOP
     * 
     * -------------------------using LONGS
     * long	    -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer
     * ulong	0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer
     * COMBOS: (18,446,744,073,709,551,61_6)^2 = 340,282,366,920,938,463,463,374,607,431,768,211,456 [perhaps using Big Integer]
     * 
     * using SZUDZIK:
     *      (ulong,ulong) -> [BigInteger]
     *      (ulong,ulong) -> [BigInteger]
     *      ([BigInteger],[BigInteger]) -> [BigInteger]         DONT
     */

    public static class _4tuple //2 type ranges [(byte/sbyte)|(ushort/short)]
    {
        #region (X,Y) -> Z

        //(sbyte/byte),(short/ushort) [4]
        //[4]^4 = 256 possible combos

        #region 1st var is sbyte

        #region 2nd var is sbyte

        //---3rd sbyte

        public static uint combine(sbyte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static uint combine(sbyte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(sbyte w, sbyte x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(sbyte w, sbyte x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static uint combine(sbyte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static uint combine(sbyte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, sbyte x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, sbyte x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(sbyte w, sbyte x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, sbyte x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, sbyte x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, sbyte x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(sbyte w, sbyte x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, sbyte x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, sbyte x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, sbyte x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is byte

        //---3rd sbyte

        public static uint combine(sbyte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static uint combine(sbyte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(sbyte w, byte x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(sbyte w, byte x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static uint combine(sbyte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static uint combine(sbyte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, byte x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, byte x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(sbyte w, byte x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, byte x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, byte x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, byte x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(sbyte w, byte x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, byte x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, byte x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, byte x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is short

        //---3rd sbyte

        public static ulong combine(sbyte w, short x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(sbyte w, short x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(sbyte w, short x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(sbyte w, short x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(sbyte w, short x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(sbyte w, short x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, short x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is ushort

        //---3rd sbyte

        public static ulong combine(sbyte w, ushort x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(sbyte w, ushort x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(sbyte w, ushort x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(sbyte w, ushort x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(sbyte w, ushort x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(sbyte w, ushort x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(sbyte w, ushort x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #endregion

        #region 1st var is byte

        #region 2nd var is sbyte

        //---3rd sbyte

        public static uint combine(byte w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static uint combine(byte w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(byte w, sbyte x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(byte w, sbyte x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static uint combine(byte w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static uint combine(byte w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, sbyte x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, sbyte x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(byte w, sbyte x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, sbyte x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, sbyte x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, sbyte x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(byte w, sbyte x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, sbyte x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, sbyte x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, sbyte x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is byte

        //---3rd sbyte

        public static uint combine(byte w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static uint combine(byte w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(byte w, byte x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(byte w, byte x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static uint combine(byte w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static uint combine(byte w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, byte x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, byte x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(byte w, byte x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, byte x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, byte x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, byte x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(byte w, byte x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, byte x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, byte x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, byte x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is short

        //---3rd sbyte

        public static ulong combine(byte w, short x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(byte w, short x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(byte w, short x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(byte w, short x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(byte w, short x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(byte w, short x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, short x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is ushort

        //---3rd sbyte

        public static ulong combine(byte w, ushort x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(byte w, ushort x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(byte w, ushort x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(byte w, ushort x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(byte w, ushort x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(byte w, ushort x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(byte w, ushort x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #endregion

        #region 1st var is ushort

        #region 2nd var is sbyte

        //---3rd sbyte

        public static ulong combine(ushort w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(ushort w, sbyte x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(ushort w, sbyte x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(ushort w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(ushort w, sbyte x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(ushort w, sbyte x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, sbyte x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is byte

        //---3rd sbyte

        public static ulong combine(ushort w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(ushort w, byte x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(ushort w, byte x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(ushort w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(ushort w, byte x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(ushort w, byte x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, byte x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is short

        //---3rd sbyte

        public static ulong combine(ushort w, short x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(ushort w, short x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(ushort w, short x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(ushort w, short x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(ushort w, short x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(ushort w, short x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, short x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is ushort

        //---3rd sbyte

        public static ulong combine(ushort w, ushort x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(ushort w, ushort x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(ushort w, ushort x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(ushort w, ushort x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(ushort w, ushort x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(ushort w, ushort x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(ushort w, ushort x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #endregion

        #region 1st var is short

        #region 2nd var is sbyte

        //---3rd sbyte

        public static ulong combine(short w, sbyte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(short w, sbyte x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(short w, sbyte x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(short w, sbyte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(short w, sbyte x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(short w, sbyte x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, sbyte x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is byte

        //---3rd sbyte

        public static ulong combine(short w, byte x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(short w, byte x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(short w, byte x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(short w, byte x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(short w, byte x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(short w, byte x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, byte x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is short

        //---3rd sbyte

        public static ulong combine(short w, short x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(short w, short x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(short w, short x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(short w, short x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(short w, short x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(short w, short x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, short x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #region 2nd var is ushort

        //---3rd sbyte

        public static ulong combine(short w, ushort x, sbyte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, sbyte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(short w, ushort x, sbyte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        public static ulong combine(short w, ushort x, sbyte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return () 

        //---3rd byte

        public static ulong combine(short w, ushort x, byte y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, byte y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, byte y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, byte y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd short

        public static ulong combine(short w, ushort x, short y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, short y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, short y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, short y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        //---3rd ushort

        public static ulong combine(short w, ushort x, ushort y, sbyte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, ushort y, byte z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, ushort y, short z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        public static ulong combine(short w, ushort x, ushort y, ushort z)
        {
            return _2tuple.combine(_2tuple.combine(w, x), _2tuple.combine(y, z));
        } //return ()

        #endregion

        #endregion

        #endregion

        #region Z -> (X,yY)

        public static byte[] reverse(uint z) //4 bytes = 2 ushorts = 1 uint
        {
            ushort[] AB_CD = _2tuple.reverse(z);
            byte[] ab = _2tuple.reverse(AB_CD[0]);
            byte[] cd = _2tuple.reverse(AB_CD[1]);
            return new byte[] { ab[0], ab[1], cd[0], cd[1] };
        }

        public static ushort[] reverse(ulong z) //4 ushorts = 2 uints = 1 ulong
        {
            uint[] AB_CD = _2tuple.reverse(z);
            ushort[] ab = _2tuple.reverse(AB_CD[0]);
            ushort[] cd = _2tuple.reverse(AB_CD[1]);
            return new ushort[] { ab[0], ab[1], cd[0], cd[1] };
        }

        #endregion
    }
}