using System;

namespace WhiteLabel.Data.Models
{
    public enum ApartmentStatus
    {
        Available = 0,
        Reviewing = 1,
        Rented = 2,
        AboutToBeAvailable = 3
    }

    public class Apartment : ModelBase
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Bedrooms { get; set; }
        public double Bathrooms { get; set; }
        public int Area { get; set; }
        public string Images { get; set; }
        public bool HasGarage { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasPool { get; set; }
        public bool HasInternet { get; set; }
        public bool HasHeating { get; set; }
        public bool HasTvCable { get; set; }
        public bool HasFireplace { get; set; }
        public Guid? Agent { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public ApartmentStatus Status { get; set; }
        public DateTime AvailableDate { get; set; }
    }
}
