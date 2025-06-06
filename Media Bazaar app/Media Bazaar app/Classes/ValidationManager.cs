using Media_Bazaar_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Media_Bazaar_app.Classes;

namespace Media_Bazaar_app.Classes
{
    class ValidationManager
    {


        public bool ValidateUserLogin(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Please enter username");
            }
            else if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Please enter password");
            }
            return true;
        }

        public bool ValidateUserDetails(string firstName, string lastName,string birthPlace, string terminationReason, string bsn, 
                                        string address, string phoneNumber, string ecName, string ecNumber, string position, 
                                        string department, string contractType, string active, string email, string username, 
                                        string password, string accountType, string zipcode)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("Please enter a first name");
            }
            else if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Please enter a last name");
            }
            else if (string.IsNullOrWhiteSpace(birthPlace) || string.IsNullOrEmpty(birthPlace))
            {
                throw new Exception("Please enter birthplace");
            }
            else if (string.IsNullOrEmpty(bsn) || string.IsNullOrWhiteSpace(bsn))
            {
                throw new Exception("Please enter BSN");
            }
            else if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Please enter a address");
            }
            else if (string.IsNullOrEmpty(zipcode) || string.IsNullOrWhiteSpace(zipcode))
            {
                throw new Exception("Please enter a zipcode");
            }
            else if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new Exception("Please enter a phone number");
            }
            else if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Please enter email address");
            }
            else if (string.IsNullOrEmpty(ecName) || string.IsNullOrWhiteSpace(ecName))
            {
                throw new Exception("Please enter an emergency contact name");
            }
            else if (string.IsNullOrEmpty(ecNumber) || string.IsNullOrWhiteSpace(ecNumber))
            {
                throw new Exception("Please enter an emergency contact phone number");
            }
            else if (string.IsNullOrEmpty(contractType))
            {
                throw new Exception("Please select contract type");
            }
            else if (string.IsNullOrEmpty(active) || string.IsNullOrWhiteSpace(active))
            {
                throw new Exception("Please select status");
            }
            else if (string.IsNullOrEmpty(accountType) || string.IsNullOrWhiteSpace(accountType))
            {
                throw new Exception("Please select account type");
            }
            else if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Please enter username");
            }
            else if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Please enter password");
            }

            if(accountType == "Floor")
            {
                if (string.IsNullOrEmpty(position))
                {
                    throw new Exception("Please select position");
                }
                else if (string.IsNullOrEmpty(department))
                {
                    throw new Exception("Please select department");
                }
            }

            if(active == "Inactive")
            {
                if (string.IsNullOrEmpty(terminationReason) || string.IsNullOrWhiteSpace(terminationReason))
                {
                    throw new Exception("Please enter termination reason");
                }
            }

            return true;
        }

        public bool ValidateProductValues(string name, string quantity, string price, string description, string department, string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please enter product id");
            }
            else if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please enter product name");
            }
            else if (string.IsNullOrEmpty(department) || string.IsNullOrWhiteSpace(department))
            {
                throw new Exception("Please chose a department");
            }
            else if (double.TryParse(price, out double dbPrice) == false)
            {
                throw new Exception("Please enter a valid price value");
            }
            else if (int.TryParse(quantity, out int depoQuantityDB) == false)
            {
                throw new Exception("Please enter a valid quantity");
            }
            else if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Please insert description");
            }
            return true;
        }

        public bool ValidateSaleProduct(string sellQuantity, int shelfQuantity)
        {
            if (string.IsNullOrEmpty(sellQuantity) || string.IsNullOrWhiteSpace(sellQuantity))
            {
                throw new Exception("Please enter a valid quantity");
            }
            if (int.TryParse(sellQuantity, out int sellQuantityDB) == false)
            {
                throw new Exception("Please enter a valid quantity");
            }
            else
            {
                if (sellQuantityDB > shelfQuantity)
                {
                    throw new Exception("Not enough stock");
                }
            }
            return true;
        }

        public bool ValidateProductRestockRequest(string restockAmount, string depotAmount)
        {
            if (string.IsNullOrEmpty(restockAmount) || string.IsNullOrWhiteSpace(restockAmount))
            {
                throw new Exception("Please insert restock amount");
            }
            else if (int.TryParse(restockAmount, out int amount) == false)
            {
                throw new Exception("Please enter a valid restock amount");
            }

            else if (string.IsNullOrWhiteSpace(depotAmount) || string.IsNullOrEmpty(depotAmount))
            {
                throw new Exception("Please select product");
            }
            else if (amount > Convert.ToInt32(depotAmount))
            {
                throw new Exception("Requested amount higher than available depot stock");
            }
            return true;
        }

        public bool ValidateGeneralMessage(string subject, string body)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrWhiteSpace(subject) || string.IsNullOrEmpty(body) || string.IsNullOrWhiteSpace(body))
            {
                throw new Exception("Please fill in required fields");
            }
            return true;
        }

        public bool ValidateNewDepartment(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please enter a valid department name");
            }

            return true;
        }

        public bool ValidatePositionValues(int cashier, int sales, int depot, int security)
        {
            if(int.TryParse(cashier.ToString(), out int number) == false)
            {
                throw new Exception("Value must be a number");
            }
            else if (int.TryParse(sales.ToString(), out int nr) == false)
            {
                throw new Exception("Value must be a number");
            }
            else if (int.TryParse(depot.ToString(), out int nb) == false)
            {
                throw new Exception("Value must be a number");
            }
            else if (int.TryParse(security.ToString(), out int no) == false)
            {
                throw new Exception("Value must be a number");
            }
            else if (string.IsNullOrEmpty(cashier.ToString()) || string.IsNullOrWhiteSpace(cashier.ToString()))
            {
                throw new Exception("Please enter value");
            }
            else if (string.IsNullOrEmpty(sales.ToString()) || string.IsNullOrWhiteSpace(sales.ToString()))
            {
                throw new Exception("Please enter value");
            }
            else if (string.IsNullOrEmpty(depot.ToString()) || string.IsNullOrWhiteSpace(depot.ToString()))
            {
                throw new Exception("Please enter value");
            }
            else if (string.IsNullOrEmpty(security.ToString()) || string.IsNullOrWhiteSpace(security.ToString()))
            {
                throw new Exception("Please enter value");
            }

            return true;
        }
    }
}
