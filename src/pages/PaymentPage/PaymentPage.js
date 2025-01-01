import React, { useState } from 'react';
import { useCart } from '../../components/Context/CartContex';
const PaymentPage = () => {
  const { cartItems, clearCart } = useCart();
  const [cardDetails, setCardDetails] = useState({
    cardNumber: '',
    expiryDate: '',
    cvv: '',
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCardDetails({ ...cardDetails, [name]: value });
  };

  const handlePayment = () => {
    if (cardDetails.cardNumber && cardDetails.expiryDate && cardDetails.cvv) {
      alert('Payment successful!');
      clearCart();
    } else {
      alert('Please fill in all the card details.');
    }
  };

  const totalPrice = cartItems.reduce((total, item) => total + parseFloat(item.price), 0);

  return (
    <div className="container py-5">
      <h2 className="mb-4">Checkout</h2>
      {cartItems.length === 0 ? (
        <div className="alert alert-warning" role="alert">
          Your cart is empty.
        </div>
      ) : (
        <>
          <div className="card mb-4">
            <div className="card-body">
              <ul className="list-group list-group-flush mb-3">
                {cartItems.map((item, index) => (
                  <li
                    className="list-group-item d-flex justify-content-between align-items-center"
                    key={index}
                  >
                    <span>{item.title}</span>
                    <span className="badge bg-primary text-white">${item.price}</span>
                  </li>
                ))}
              </ul>
              <div className="d-flex justify-content-between align-items-center">
                <strong>Total:</strong>
                <span className="text-success">${totalPrice.toFixed(2)}</span>
              </div>
            </div>
          </div>

          <h3 className="mb-3">Payment Details</h3>
          <div className="card">
            <div className="card-body">
              <div className="mb-3">
                <label htmlFor="cardNumber" className="form-label">
                  Card Number
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="cardNumber"
                  name="cardNumber"
                  placeholder="1234 5678 9101 1121"
                  value={cardDetails.cardNumber}
                  onChange={handleInputChange}
                />
              </div>
              <div className="mb-3">
                <label htmlFor="expiryDate" className="form-label">
                  Expiry Date
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="expiryDate"
                  name="expiryDate"
                  placeholder="MM/YY"
                  value={cardDetails.expiryDate}
                  onChange={handleInputChange}
                />
              </div>
              <div className="mb-3">
                <label htmlFor="cvv" className="form-label">
                  CVV
                </label>
                <input
                  type="password"
                  className="form-control"
                  id="cvv"
                  name="cvv"
                  placeholder="123"
                  value={cardDetails.cvv}
                  onChange={handleInputChange}
                />
              </div>
              <button className="btn btn-success w-100" onClick={handlePayment}>
                Pay ${totalPrice.toFixed(2)}
              </button>
            </div>
          </div>
        </>
      )}
    </div>
  );
};

export default PaymentPage;
