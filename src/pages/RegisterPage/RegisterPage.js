import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Form, FormGroup, Label, Input, Button, Row, Col, Card } from 'reactstrap';
import { FaUserAlt, FaLock, FaEnvelope } from 'react-icons/fa';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faGraduationCap } from '@fortawesome/free-solid-svg-icons';

const MinimalNavbar = () => (
  <nav
    className="navbar navbar-light bg-light shadow-sm"
    style={{
      padding: '10px 20px',
      position: 'fixed',
      top: 0,
      width: '100%',
      zIndex: 1000,
    }}
  >
    <div className="d-flex align-items-center">
      <FontAwesomeIcon icon={faGraduationCap} className="me-2 text-primary" size="lg" />
      <span className="navbar-brand fw-bold mb-0 text-dark">Course Management</span>
    </div>
  </nav>
);

const SignUpPage = () => {
  const [fullName, setFullName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSignUp = (e) => {
    e.preventDefault();
    console.log('Sign Up:', { fullName, email, password });
    navigate('/dashboard');
  };

  return (
    <div>
      <MinimalNavbar />

      <div
        className="vh-100 d-flex align-items-center justify-content-center"
        style={{
          backgroundImage: 'url(https://images.pexels.com/photos/4145153/pexels-photo-4145153.jpeg?auto=compress&cs=tinysrgb&w=1200)',
          backgroundSize: 'cover',
          backgroundPosition: 'center',
          filter: 'brightness(0.8)',
          paddingTop: '70px',
        }}
      >
        <Card
          className="shadow-lg"
          style={{
            width: '100%',
            maxWidth: '900px',
            borderRadius: '20px',
            background: 'rgba(255, 255, 255, 0.95)', 
            boxShadow: '0 6px 20px rgba(0, 0, 0, 0.15)',
            overflow: 'hidden',
          }}
        >
          <Row noGutters>
            <Col md={6} className="p-5" style={{ background: '#f8f9fa' }}>
              <h2 className="mb-4 text-primary" style={{ fontWeight: 'bold' }}>Welcome!</h2>
              <p style={{ fontSize: '1.1rem', color: '#6c757d' }}>
                Join us to explore amazing courses and improve your skills.
              </p>
              <Button
                color="primary"
                className="mt-4"
                onClick={() => navigate('/login')}
                style={{
                  borderRadius: '25px',
                  fontWeight: 'bold',
                  background: 'linear-gradient(to right, #ff7e5f, #feb47b)',
                  border: 'none',
                }}
              >
                Login
              </Button>
            </Col>

            <Col md={6} className="p-5">
              <h3 className="text-center mb-4" style={{ fontWeight: 'bold', color: '#333' }}>Sign Up</h3>
              <Form onSubmit={handleSignUp}>
                <FormGroup>
                  <Label for="fullName" style={{ fontWeight: 'bold' }}>Full Name</Label>
                  <div className="input-group mb-3">
                    <span className="input-group-text bg-light border-0" style={{ borderRadius: '25px 0 0 25px' }}>
                      <FaUserAlt />
                    </span>
                    <Input
                      type="text"
                      id="fullName"
                      placeholder="Enter your full name"
                      value={fullName}
                      onChange={(e) => setFullName(e.target.value)}
                      required
                      style={{ borderRadius: '0 25px 25px 0' }}
                    />
                  </div>
                </FormGroup>
                <FormGroup>
                  <Label for="email" style={{ fontWeight: 'bold' }}>Email</Label>
                  <div className="input-group mb-3">
                    <span className="input-group-text bg-light border-0" style={{ borderRadius: '25px 0 0 25px' }}>
                      <FaEnvelope />
                    </span>
                    <Input
                      type="email"
                      id="email"
                      placeholder="Enter your email"
                      value={email}
                      onChange={(e) => setEmail(e.target.value)}
                      required
                      style={{ borderRadius: '0 25px 25px 0' }}
                    />
                  </div>
                </FormGroup>
                <FormGroup>
                  <Label for="password" style={{ fontWeight: 'bold' }}>Password</Label>
                  <div className="input-group mb-3">
                    <span className="input-group-text bg-light border-0" style={{ borderRadius: '25px 0 0 25px' }}>
                      <FaLock />
                    </span>
                    <Input
                      type="password"
                      id="password"
                      placeholder="Enter your password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      required
                      style={{ borderRadius: '0 25px 25px 0' }}
                    />
                  </div>
                </FormGroup>
                <Button
                  color="primary"
                  type="submit"
                  className="w-100 mt-3"
                  style={{
                    borderRadius: '25px',
                    fontWeight: 'bold',
                    background: 'linear-gradient(to right, #6a11cb, #2575fc)',
                    border: 'none',
                  }}
                >
                  Sign Up
                </Button>
              </Form>
            </Col>
          </Row>
        </Card>
      </div>
    </div>
  );
};

export default SignUpPage;
