import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Form, FormGroup, Label, Input, Button, Row, Col, Card, CardBody, CardTitle } from 'reactstrap';

const RegisterPage = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleRegister = (e) => {
    e.preventDefault();
    console.log('Register:', { name, email, password });
    navigate('/login');
  };

  return (
    <Row className="vh-100 align-items-center justify-content-center bg-light">
      <Col md={8} lg={6}>
        <Card className="shadow border-0">
          <Row noGutters>
            <Col md={6} className="bg-primary text-white p-5">
              <div className="text-center">
                <h2>Welcome!</h2>
                <p>To start your journey, please create an account.</p>
                <Button color="light" onClick={() => navigate('/login')}>
                  Login
                </Button>
              </div>
            </Col>
            <Col md={6}>
              <CardBody className="p-5">
                <CardTitle tag="h3" className="text-center mb-4">
                  Create Account
                </CardTitle>
                <Form onSubmit={handleRegister}>
                  <FormGroup>
                    <Label for="name">Name</Label>
                    <Input
                      type="text"
                      id="name"
                      placeholder="Enter your name"
                      value={name}
                      onChange={(e) => setName(e.target.value)}
                      required
                    />
                  </FormGroup>
                  <FormGroup>
                    <Label for="email">Email</Label>
                    <Input
                      type="email"
                      id="email"
                      placeholder="Enter your email"
                      value={email}
                      onChange={(e) => setEmail(e.target.value)}
                      required
                    />
                  </FormGroup>
                  <FormGroup>
                    <Label for="password">Password</Label>
                    <Input
                      type="password"
                      id="password"
                      placeholder="Enter your password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      required
                    />
                  </FormGroup>
                  <Button color="primary" type="submit" className="w-100 mt-3">
                    Sign Up
                  </Button>
                </Form>
              </CardBody>
            </Col>
          </Row>
        </Card>
      </Col>
    </Row>
  );
};

export default RegisterPage;
