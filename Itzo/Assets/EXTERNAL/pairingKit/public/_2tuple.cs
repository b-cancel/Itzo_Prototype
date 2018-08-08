namespace pairingKit
{
    /// <summary>
    /// Description: public functions for 2 tuple pairing
    //      1. cast the smaller type into the larger type
    //      2. use the version of the pairing function that uses 2 of the larger types in BASE
    /// Programmer: Bryan Cancel
    /// Reason For Existance: 
    ///     -you might want to pair any 2 integral numbers
    /// Combine Sequence (a,b) -> z
    /// Reverse Sequence z -> (a,b)
    /// </summary>

    public static class _2tuple //3 type ranges [(byte/sbyte)|(ushort/short)|(uint,int)]
    {
        #region (X,Y) -> Z

        //(sbyte/byte),(short/ushort),(int/uint) [6]
        //[6]^2 = 36 possible combos

        #region starting with sbyte

        public static ushort combine(sbyte x, sbyte y) {
            return tupleBase.sbyteSzudzik2tupleCombine(x, y);
        } //return (ushort)

        public static ushort combine(sbyte x, byte y) {
            return tupleBase.byteSzudzik2tupleCombine(tupleBase.sbyteToByte(x), y);
        } //return (ushort)

        public static uint combine(sbyte x, short y) {
            return tupleBase.shortSzudzik2tupleCombine((short)x, y);
        } //return (uint)

        public static uint combine(sbyte x, ushort y) {
            return tupleBase.ushortSzudzik2tupleCombine((ushort)tupleBase.sbyteToByte(x), y);
        } //return (uint)

        public static ulong combine(sbyte x, int y) {
            return tupleBase.intSzudzik2tupleCombine((int)x, y);
        } //return (ulong)

        public static ulong combine(sbyte x, uint y) {
            return tupleBase.uintSzudzik2tupleCombine((uint)tupleBase.sbyteToByte(x), y);
        } //return (ulong)

        #endregion

        #region starting with byte

        public static ushort combine(byte x, sbyte y) {
            return tupleBase.byteSzudzik2tupleCombine(x, tupleBase.sbyteToByte(y));
        } //return (ushort)

        public static ushort combine(byte x, byte y) {
            return tupleBase.byteSzudzik2tupleCombine(x, y);
        } //return (ushort)

        public static uint combine(byte x, short y) {
            return tupleBase.ushortSzudzik2tupleCombine((ushort)x, tupleBase.shortToUshort(y));
        } //return (uint)

        public static uint combine(byte x, ushort y) {
            return tupleBase.ushortSzudzik2tupleCombine((ushort)x, y);
        } //return (uint)

        public static ulong combine(byte x, int y) {
            return tupleBase.uintSzudzik2tupleCombine((uint)x, tupleBase.intToUint(y));
        } //return (ulong)

        public static ulong combine(byte x, uint y) {
            return tupleBase.uintSzudzik2tupleCombine((uint)x, y);
        } //return (ulong)

        #endregion

        #region starting with short

        public static uint combine(short x, sbyte y) {
            return tupleBase.shortSzudzik2tupleCombine(x, (short)y);
        } //return (uint)

        public static uint combine(short x, byte y) {
            return tupleBase.ushortSzudzik2tupleCombine(tupleBase.shortToUshort(x), (ushort)y);
        } //return (uint)

        public static uint combine(short x, short y) {
            return tupleBase.shortSzudzik2tupleCombine(x, y);
        } //return (uint)

        public static uint combine(short x, ushort y) {
            return tupleBase.ushortSzudzik2tupleCombine(tupleBase.shortToUshort(x), y);
        } //return (uint)

        public static ulong combine(short x, int y) {
            return tupleBase.intSzudzik2tupleCombine((int)x, y);
        } //return (ulong)

        public static ulong combine(short x, uint y) {
            return tupleBase.uintSzudzik2tupleCombine((uint)tupleBase.shortToUshort(x), y);
        } //return (ulong)

        #endregion

        #region starting with ushort

        public static uint combine(ushort x, sbyte y) {
            return tupleBase.ushortSzudzik2tupleCombine(x, (ushort)tupleBase.sbyteToByte(y));
        } //return (uint)

        public static uint combine(ushort x, byte y) {
            return tupleBase.ushortSzudzik2tupleCombine(x, (ushort)y);
        } //return (uint)

        public static uint combine(ushort x, short y) {
            return tupleBase.ushortSzudzik2tupleCombine(x, tupleBase.shortToUshort(y));
        } //return (uint)

        public static uint combine(ushort x, ushort y) {
            return tupleBase.ushortSzudzik2tupleCombine(x, y);
        } //return (uint)

        public static ulong combine(ushort x, int y) {
            return tupleBase.uintSzudzik2tupleCombine((uint)x, tupleBase.intToUint(y));
        } //return (ulong)

        public static ulong combine(ushort x, uint y) {
            return tupleBase.uintSzudzik2tupleCombine((uint)x, y);
        } //return (ulong)

        #endregion

        #region starting with int

        public static ulong combine(int x, sbyte y) {
            return tupleBase.intSzudzik2tupleCombine(x, (int)y);
        } //return (ulong)

        public static ulong combine(int x, byte y) {
            return tupleBase.uintSzudzik2tupleCombine(tupleBase.intToUint(x), (uint)y);
        } //return (ulong)

        public static ulong combine(int x, short y) {
            return tupleBase.intSzudzik2tupleCombine(x, (int)y);
        } //return (ulong)

        public static ulong combine(int x, ushort y) {
            return tupleBase.uintSzudzik2tupleCombine(tupleBase.intToUint(x), (uint)y);
        } //return (ulong)

        public static ulong combine(int x, int y) {
            return tupleBase.intSzudzik2tupleCombine(x, y);
        } //return (ulong)

        public static ulong combine(int x, uint y) {
            return tupleBase.uintSzudzik2tupleCombine(tupleBase.intToUint(x), y);
        } //return (ulong)

        #endregion

        #region starting with uint

        public static ulong combine(uint x, sbyte y) {
            return tupleBase.uintSzudzik2tupleCombine(x, (uint)tupleBase.sbyteToByte(y));
        } //return (ulong)

        public static ulong combine(uint x, byte y) {
            return tupleBase.uintSzudzik2tupleCombine(x, (uint)y);
        } //return (ulong)

        public static ulong combine(uint x, short y) {
            return tupleBase.uintSzudzik2tupleCombine(x, (uint)tupleBase.shortToUshort(y));
        } //return (ulong)

        public static ulong combine(uint x, ushort y) {
            return tupleBase.uintSzudzik2tupleCombine(x, (uint)y);
        } //return (ulong)

        public static ulong combine(uint x, int y) {
            return tupleBase.uintSzudzik2tupleCombine(x, tupleBase.intToUint(y));
        } //return (ulong)

        public static ulong combine(uint x, uint y) {
            return tupleBase.uintSzudzik2tupleCombine(x, y);
        } //return (ulong)

        #endregion

        #endregion

        #region Z -> (X,Y)

        public static byte[] reverse(ushort z) {
            return tupleBase.byteSzudzik2tupleReverse(z);
        } 

        public static ushort[] reverse(uint z) {
            return tupleBase.ushortSzudzik2tupleReverse(z);
        } 

        public static uint[] reverse(ulong z) {
            return tupleBase.uintSzudzik2tupleReverse(z);
        } 

        #endregion
    }
}