using System;
using Castle.Components.Validator;

namespace TrackMan.Framework.Assets
{
    public class Asset
    {
        #region Constructors

        public Asset(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
                throw new ArgumentException("Serial number cannot be empty or null.");

            SerialNumber = serialNumber;
        }

        #endregion

        #region Public properties

        public string SerialNumber { get; private set; }

        [ValidateNonEmpty("AssetBlankBrand")]
        [ValidateLength(1, 255, "AssetBrandLength")]
        public string Brand { get; set; }

        [ValidateNonEmpty("AssetLocationBlank")]
        [ValidateLength(1, 255, "AssetLocationLength")]
        public string Location { get; set; }

        [ValidateRange(RangeValidationType.Decimal, 0.01, 1500000.00, "AssetCostRange")]
        public decimal Cost { get; set; }

        [ValidateRange(1, int.MaxValue, "AssetRoomRange")]
        public int RoomId { get; set; }

        #endregion

        #region Object overrides

        public override bool Equals(object obj)
        {
            var other = obj as Asset;
            return (other != null && other.SerialNumber.Equals(SerialNumber));
        }

        public override int GetHashCode()
        {
            return SerialNumber.GetHashCode();
        }

        public override string ToString()
        {
            return SerialNumber;
        }

        #endregion
    }
}