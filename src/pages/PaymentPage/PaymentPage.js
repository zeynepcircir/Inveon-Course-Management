import React, { useState } from 'react';
import { Container, Row, Col, Form, FormGroup, Label, Input, Button, Card } from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const PaymentPage = () => {
  const [cardDetails, setCardDetails] = useState({
    fullName: '',
    cardNumber: '',
    expiryDate: '',
    cvv: '',
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCardDetails({ ...cardDetails, [name]: value });
  };

  return (
    <Container className="py-5" style={{ marginTop: '50px' }}>
      <Row>
        {/* Sol Kısım - Input Alanları */}
        <Col md={6} className="mb-4">
          <h3 className="mb-4">Payment Details</h3>
          <Form>
            <FormGroup>
              <Label for="fullName">Card Holder Full Name</Label>
              <Input
                type="text"
                name="fullName"
                id="fullName"
                placeholder="John Doe"
                value={cardDetails.fullName}
                onChange={handleInputChange}
                className="shadow-sm"
              />
            </FormGroup>
            <FormGroup>
              <Label for="cardNumber">Card Number</Label>
              <Input
                type="text"
                name="cardNumber"
                id="cardNumber"
                placeholder="1234 5678 9101 1121"
                value={cardDetails.cardNumber}
                onChange={handleInputChange}
                maxLength={16}
                className="shadow-sm"
              />
            </FormGroup>
            <Row>
              <Col>
                <FormGroup>
                  <Label for="expiryDate">Expiry Date</Label>
                  <Input
                    type="text"
                    name="expiryDate"
                    id="expiryDate"
                    placeholder="MM/YY"
                    value={cardDetails.expiryDate}
                    onChange={handleInputChange}
                    maxLength={5}
                    className="shadow-sm"
                  />
                </FormGroup>
              </Col>
              <Col>
                <FormGroup>
                  <Label for="cvv">CVV</Label>
                  <Input
                    type="password"
                    name="cvv"
                    id="cvv"
                    placeholder="123"
                    value={cardDetails.cvv}
                    onChange={handleInputChange}
                    maxLength={3}
                    className="shadow-sm"
                  />
                </FormGroup>
              </Col>
            </Row>
            <Button color="success" className="w-100 shadow">
              Complete Payment
            </Button>
          </Form>
        </Col>

        {/* Sağ Kısım - Kart Görünümü */}
        <Col md={6}>
          <Card
            className="p-3 shadow-sm"
            style={{
              background: 'linear-gradient(145deg, #e0f7fa, #004d40)',
              color: 'white',
              borderRadius: '15px',
              maxWidth: '350px',
              margin: '0 auto',
              boxShadow: '0 4px 8px rgba(0, 0, 0, 0.2)',
            }}
          >
            <div className="mb-4">
              <div
                className="chip bg-warning rounded"
                style={{ width: '50px', height: '30px' }}
              ></div>
            </div>
            <h5 className="mb-3" style={{ letterSpacing: '2px', fontSize: '1.2rem' }}>
              {cardDetails.cardNumber.padEnd(16, '•').replace(/(.{4})/g, '$1 ')}
            </h5>
            <div className="d-flex justify-content-between mb-2">
              <div>
                <small>Card Holder</small>
                <p className="mb-0">{cardDetails.fullName || 'FULL NAME'}</p>
              </div>
              <div>
                <small>Expires</small>
                <p className="mb-0">{cardDetails.expiryDate || 'MM/YY'}</p>
              </div>
            </div>
            <div>
              <small>CVV</small>
              <p className="mb-0">{cardDetails.cvv || '•••'}</p>
            </div>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default PaymentPage;
