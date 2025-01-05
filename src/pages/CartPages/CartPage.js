import React, { useState } from 'react';
import {
  Container,
  Row,
  Col,
  Table,
  Button,
} from 'reactstrap';
import { FaTrash } from 'react-icons/fa';
import courses from '../../data/courses'; 

const CartPage = () => {
  const [cart, setCart] = useState(
    courses.slice(0, 3).map((course) => ({
      ...course,
      quantity: 1,
      price: course.price === 'Free' ? 0 : parseFloat(course.price.replace('$', '')),
    }))
  );

  const handleRemove = (id) => {
    setCart(cart.filter((item) => item.id !== id));
  };

  const handleClearCart = () => {
    setCart([]);
  };

  const totalAmount = cart.reduce(
    (total, item) => total + item.price * item.quantity,
    0
  );

  return (
    <Container className="py-5">
      <h2 className="text-center mb-4">Your Cart</h2>
      <p className="text-center text-muted">
        Review the items in your cart before proceeding to checkout.
      </p>

      {cart.length > 0 ? (
        <>
          <Table bordered className="mb-4">
            <thead>
              <tr>
                <th>Image</th>
                <th>Title</th>
                <th>Category</th>
                <th>Price</th>
                <th>Quantity</th>
                <th>Total</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {cart.map((item) => (
                <tr key={item.id}>
                  <td>
                    <img
                      src={item.image}
                      alt={item.title}
                      style={{ width: '80px', height: '50px', objectFit: 'cover' }}
                    />
                  </td>
                  <td>{item.title}</td>
                  <td>{item.category}</td>
                  <td>${item.price.toFixed(2)}</td>
                  <td>{item.quantity}</td>
                  <td>${(item.price * item.quantity).toFixed(2)}</td>
                  <td>
                    <Button
                      color="danger"
                      size="sm"
                      onClick={() => handleRemove(item.id)}
                    >
                      <FaTrash />
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>

          <Row className="justify-content-between align-items-center">
            <Col md={6}>
              <Button color="warning" onClick={handleClearCart}>
                Clear Cart
              </Button>
            </Col>
            <Col md={6} className="text-end">
              <h5>Total Amount: ${totalAmount.toFixed(2)}</h5>
            </Col>
          </Row>
        </>
      ) : (
        <div className="text-center">
          <h4 className="text-muted">Your cart is empty.</h4>
        </div>
      )}
    </Container>
  );
};

export default CartPage;
