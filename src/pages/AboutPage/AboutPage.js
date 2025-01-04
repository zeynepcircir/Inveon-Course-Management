import React from 'react';
import { Container, Row, Col, Card, CardBody } from 'reactstrap';
import { FaUserCircle, FaFacebook, FaTwitter, FaLinkedin } from 'react-icons/fa';
import 'bootstrap/dist/css/bootstrap.min.css';

const AboutPage = () => {
  return (
    <Container className="py-5">
      <Row className="mb-4">
        <Col className="text-center">
          <h1 className="fw-bold">About Us</h1>
          <p className="text-muted">
            Learn more about our mission, values, and the journey behind Course Management.
          </p>
        </Col>
      </Row>

      {/* Mission and Vision */}
      <Row className="gy-4">
        <Col md={6}>
          <Card className="shadow-sm">
            <CardBody>
              <h4 className="fw-bold">Our Mission</h4>
              <p>
                At Course Management, our mission is to provide accessible, high-quality education to learners around the globe. 
                We aim to empower individuals to achieve their full potential by offering a wide range of courses tailored to their goals.
              </p>
            </CardBody>
          </Card>
        </Col>

        <Col md={6}>
          <Card className="shadow-sm">
            <CardBody>
              <h4 className="fw-bold">Our Vision</h4>
              <p>
                Our vision is to create a world where knowledge is freely accessible to everyone. 
                We aspire to be the leading platform in online education, fostering growth, innovation, and community.
              </p>
            </CardBody>
          </Card>
        </Col>
      </Row>

      {/* Team Members */}
      <Row className="mt-5">
        <Col className="text-center mb-4">
          <h2 className="fw-bold">Meet Our Team</h2>
          <p className="text-muted">A group of dedicated professionals committed to your success.</p>
        </Col>
      </Row>
      <Row className="gy-4">
        <Col md={4}>
          <Card className="shadow-sm">
            <CardBody className="text-center">
              <FaUserCircle size={100} className="text-muted mb-3" />
              <h5 className="fw-bold">John Doe</h5>
              <p className="text-muted">CEO & Founder</p>
              <div className="d-flex justify-content-center gap-3 mt-2">
                <FaFacebook size={20} className="text-primary" />
                <FaTwitter size={20} className="text-info" />
                <FaLinkedin size={20} className="text-primary" />
              </div>
            </CardBody>
          </Card>
        </Col>

        <Col md={4}>
          <Card className="shadow-sm">
            <CardBody className="text-center">
              <FaUserCircle size={100} className="text-muted mb-3" />
              <h5 className="fw-bold">Jane Smith</h5>
              <p className="text-muted">Head of Operations</p>
              <div className="d-flex justify-content-center gap-3 mt-2">
                <FaFacebook size={20} className="text-primary" />
                <FaTwitter size={20} className="text-info" />
                <FaLinkedin size={20} className="text-primary" />
              </div>
            </CardBody>
          </Card>
        </Col>

        <Col md={4}>
          <Card className="shadow-sm">
            <CardBody className="text-center">
              <FaUserCircle size={100} className="text-muted mb-3" />
              <h5 className="fw-bold">Mark Johnson</h5>
              <p className="text-muted">Lead Developer</p>
              <div className="d-flex justify-content-center gap-3 mt-2">
                <FaFacebook size={20} className="text-primary" />
                <FaTwitter size={20} className="text-info" />
                <FaLinkedin size={20} className="text-primary" />
              </div>
            </CardBody>
          </Card>
        </Col>
      </Row>

      {/* Footer Information */}
      <Row className="mt-5">
        <Col className="text-center">
          <p className="text-muted">&copy; 2025 Course Management. All rights reserved.</p>
        </Col>
      </Row>
    </Container>
  );
};

export default AboutPage;
