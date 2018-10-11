using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if(!textBoxDataIsValid())
            {
                return;
            }

            PapaBobs.DTO.OrderDTO orderDTO = new DTO.OrderDTO();

            orderDTO.Size = determineSize();
            orderDTO.Crust = determineCrust();
            orderDTO.Sausage = sausageCheckBox.Checked;
            orderDTO.Pepperoni = pepperoniCheckbox.Checked;
            orderDTO.Onions = onionCheckBox.Checked;
            orderDTO.GreenPeppers = greenPepperCheckBox.Checked;
            orderDTO.Name = nameTextBox.Text;
            orderDTO.Address = addressTextbox.Text;
            orderDTO.ZipCode = zipCodeTextBox.Text;
            orderDTO.Phone = phoneTextBox.Text;
            orderDTO.PaymentType = determinePayment();

            // Call to the Domain layer's CreateOrder()
            Domain.OrderManager.CreateOrder(orderDTO);
        }

        private bool textBoxDataIsValid()
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError("name");
                return false;
            }
            else if (addressTextbox.Text.Trim().Length == 0)
            {
                textBoxValidationError("address");
                return false;
            }
            else if (zipCodeTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError("zip code");
                return false;
            }
            else if (phoneTextBox.Text.Trim().Length == 0)
            {
                textBoxValidationError("phone number");
                return false;
            }
            else
                return true;
        }

        private DTO.Enums.PaymentType determinePayment()
        {
            DTO.Enums.PaymentType paymentMethod;

            if (cashRadio.Checked)
                paymentMethod = DTO.Enums.PaymentType.Cash;
            else
                paymentMethod = DTO.Enums.PaymentType.Credit;

            return paymentMethod;
        }

        private DTO.Enums.SizeType determineSize()
        {
            DTO.Enums.SizeType size;

            // Uses dropdowns selected value so nothing needs to be passed in.
            if(!Enum.TryParse(sizeDropDown.SelectedValue, out size))
            {
                throw new Exception("Could not determine Pizza size.");
            }

            return size;
        }

        private DTO.Enums.CrustType determineCrust()
        {
            DTO.Enums.CrustType crust;

            if (!Enum.TryParse(crustDropDown.SelectedValue, out crust))
            {
                throw new Exception("Could not determine Pizza crust.");
            }

            return crust;
        }

        private void textBoxValidationError(string errorType)
        {
            string errorMessage = "";
            errorMessage += string.Format("<strong>Please enter a {0}.</strong>", errorType);

            // Set label to label to error message and make visible.
            validationLabel.Text = errorMessage;
            validationLabel.Visible = true;
        }
    }
}