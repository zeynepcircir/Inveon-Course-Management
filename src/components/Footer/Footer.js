import React from 'react';
import { Container, Row, Col } from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useTheme } from '../../App'; 
import { right } from '@popperjs/core';

const Footer = () => {
  const { darkMode } = useTheme(); 

  return (
    <footer
      style={{
        background: darkMode ? '#343a40' : '#f8f9fa', 
        color: darkMode ? '#adb5bd' : '#6c757d', 
        borderTop: darkMode ? '1px solid #495057' : '1px solid #dee2e6',
        borderRadius: '10px 10px 0 0',
        boxShadow: '0 -2px 5px rgba(0, 0, 0, 0.1)',
        fontSize: '0.85rem',
        padding: '10px 15px',
        marginTop: '50px',
        marginLeft: '15.5rem',
      }}
    >
      <Container>
        <Row>
          <Col md={4} sm={12} className="mb-2">
            <h6 className={`fw-bold mb-1 ${darkMode ? 'text-light' : 'text-dark'}`}>
              Course Management
            </h6>
            <p style={{ marginBottom: '5px' }}>
              Your trusted platform for learning and growth.
            </p>
          </Col>

          <Col md={4} sm={12} className="mb-2">
            <h6 className={`fw-bold mb-1 ${darkMode ? 'text-light' : 'text-dark'}`}>
              Quick Links
            </h6>
            <ul className="list-unstyled" style={{ marginBottom: '5px' }}>
              <li>
                <a
                  href="/"
                  className={`text-decoration-none ${darkMode ? 'text-light' : 'text-secondary'}`}
                >
                  Home
                </a>
              </li>
              <li>
                <a
                  href="/about"
                  className={`text-decoration-none ${darkMode ? 'text-light' : 'text-secondary'}`}
                >
                  About
                </a>
              </li>
            </ul>
          </Col>
          <Col md={4} sm={12} className="mb-2">
            <h6 className={`fw-bold mb-1 ${darkMode ? 'text-light' : 'text-dark'}`}>
              Contact Us
            </h6>
            <p style={{ marginBottom: '5px' }}>
              <strong>Email:</strong> info@coursemanagement.com
              <br />
              <strong>Phone:</strong> +1 123 456 789
              <br />
              <strong>Address:</strong> 123 Learning St, Knowledge City
            </p>
          </Col>
        </Row>

        <Row>
          <Col className="text-center mt-2">
            <small>© 2025 Course Management. All Rights Reserved.</small>
          </Col>
        </Row>
      </Container>
    </footer>
  );
};

export default Footer;
