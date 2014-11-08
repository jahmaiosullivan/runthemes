using System;
using System.Collections.Generic;
using WhiteLabel.Data.Models;

namespace WhiteLabel.Web.ViewModels
{
    public class ApartmentViewModel
    {
        public long Id { get; set; }

        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Bedrooms { get; set; }
        public double Bathrooms { get; set; }
        public int Area { get; set; }
        public IEnumerable<string> Images { get; set; }
        public bool HasGarage { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasPool { get; set; }
        public bool HasInternet { get; set; }
        public bool HasHeating { get; set; }
        public bool HasTvCable { get; set; }
        public bool HasFireplace { get; set; }
        public UserViewModel Agent { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public ApartmentStatus Status { get; set; }
        public DateTime AvailableDate { get; set; }
    }
}
