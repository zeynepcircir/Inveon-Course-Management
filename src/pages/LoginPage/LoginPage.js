import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { Form, FormGroup, Label, Input, Button, Row, Col, Card, CardBody } from 'reactstrap';
import { FaUserAlt, FaLock } from 'react-icons/fa';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faGraduationCap } from '@fortawesome/free-solid-svg-icons';
import axiosInstance from '../../api/axios'; 
import API_ENDPOINTS from '../../api/endpoints'; 

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
      <Link to="/" className="navbar-brand fw-bold mb-0 text-dark">
        Course Management
      </Link>
    </div>
  </nav>
);

const LoginPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.post(API_ENDPOINTS.auth.login, {
        email,
        password,
      });
      localStorage.setItem('token', response.data.data.token);
      navigate('/dashboard'); 
    } catch (error) {
      console.error('Login failed:', error);
    }
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
            background: 'rgba(255, 255, 255, 0.96)', 
            boxShadow: '0 6px 20px rgba(0, 0, 0, 0.15)', 
            overflow: 'hidden',
          }}
        >
          <Row noGutters>
            <Col md={6} className="p-5" style={{ background: 'white' }}>
              <h2 className="mb-4 text-primary" style={{ fontWeight: 'bold' }}>Welcome Back!</h2>
              <p style={{ fontSize: '1.1rem', color: '#6c757d' }}>
                To keep connected with us, please login with your personal info.
              </p>
              <Button
                color="primary"
                className="mt-4"
                onClick={() => navigate('/register')}
                style={{
                  borderRadius: '25px',
                  fontWeight: 'bold',
                  background: 'linear-gradient(to right, #ff7e5f, #feb47b)',
                  border: 'none',
                }}
              >
                Sign Up
              </Button>
            </Col>

            <Col md={6} className="p-5">
              <h3 className="text-center mb-4" style={{ fontWeight: 'bold', color: '#333' }}>Login</h3>
              <Form onSubmit={handleLogin}>
                <FormGroup>
                  <Label for="email" style={{ fontWeight: 'bold' }}>Email</Label>
                  <div className="input-group mb-3">
                    <span className="input-group-text bg-light border-0" style={{ borderRadius: '25px 0 0 25px' }}>
                      <FaUserAlt />
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
                  Login
                </Button>
              </Form>
            </Col>
          </Row>
        </Card>
      </div>
    </div>
  );
};

export default LoginPage;
