import React from 'react';
import { useParams } from 'react-router-dom';
import { Container, Row, Col, Card, CardBody, CardText, Button, Badge } from 'reactstrap';

// Mock veri (gerçek veri backend'den API ile alınacak)
const courses = [
  {
    id: 1,
    title: 'Cinematic Techniques',
    category: 'Filming',
    price: 'Free',
    chapters: 4,
    description: 'Learn the best cinematic techniques to make your videos look professional.',
    image: 'https://via.placeholder.com/150',
    content: ['Introduction', 'Lighting Basics', 'Camera Angles', 'Advanced Techniques'],
  },
  {
    id: 2,
    title: 'Introduction to Filming',
    category: 'Filming',
    price: '$20',
    chapters: 2,
    description: 'A beginner-friendly course to get started with filming and video production.',
    image: 'https://via.placeholder.com/150',
    content: ['Overview', 'Getting Started'],
  },
  {
    id: 3,
    title: 'Structural Design Principles',
    category: 'Engineering',
    price: '$15',
    chapters: 10,
    description: 'Master the principles of structural design and engineering fundamentals.',
    image: 'https://via.placeholder.com/150',
    content: ['Introduction', 'Load Analysis', 'Design Methods', 'Case Studies'],
  },
];

const CourseDetailPage = () => {
  const { id } = useParams(); // URL'den kurs ID'sini alıyoruz
  const course = courses.find((c) => c.id === parseInt(id)); // Mock veriden kursu buluyoruz

  if (!course) {
    return (
      <Container className="py-5 text-center">
        <h1>Course not found!</h1>
        <p>It seems this course does not exist or has been removed.</p>
      </Container>
    );
  }

  return (
    <Container className="py-5">
      <Row>
        <Col md={6}>
          <img src={course.image} alt={course.title} className="img-fluid rounded" />
        </Col>
        <Col md={6}>
          <h1>{course.title}</h1>
          <Badge color="primary" className="mb-3">
            {course.category}
          </Badge>
          <p>{course.description}</p>
          <h4>Price: {course.price}</h4>
          <Button color="success" className="mt-3">
            Enroll Now
          </Button>
        </Col>
      </Row>
      <Row className="mt-5">
        <Col>
          <h3>Course Content</h3>
          <ul>
            {course.content.map((item, index) => (
              <li key={index}>{item}</li>
            ))}
          </ul>
        </Col>
      </Row>
    </Container>
  );
};

export default CourseDetailPage;
