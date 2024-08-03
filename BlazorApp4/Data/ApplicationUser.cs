using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp4.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string ? FirstName { get; set; }
        public string? LastName { get; set; }

        // Billing information
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingZip { get; set; }
        public string? BillingCountry { get; set; }
        public string? CreditCardNo { get; set; }
        public string? CreditCardExp { get; set; }
        public string? CreditCardCvv { get; set; }
    }

}
