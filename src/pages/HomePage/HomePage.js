import React from 'react';
import { Container, Row, Col, Card, CardBody, CardTitle, CardText, Button, Progress } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

// Mock veri (backend hazır olunca API'den çekilebilir)
const courses = [
  {
    id: 1,
    title: 'Cinematic Techniques',
    category: 'Filming',
    price: 'Free',
    progress: 100,
    chapters: 4,
    image: 'https://via.placeholder.com/150',
    description: 'Learn the best cinematic techniques to make your videos look professional.',
  },
  {
    id: 2,
    title: 'Introduction to Filming',
    category: 'Filming',
    price: '$20',
    progress: 50,
    chapters: 2,
    image: 'https://via.placeholder.com/150',
    description: 'A beginner-friendly course to get started with filming and video production.',
  },
  {
    id: 3,
    title: 'Structural Design Principles',
    category: 'Engineering',
    price: '$15',
    progress: 30,
    chapters: 10,
    image: 'https://via.placeholder.com/150',
    description: 'Master the principles of structural design and engineering fundamentals.',
  },
];

const HomePage = () => {
  const navigate = useNavigate();

  return (
    <Container className="py-5">
      <h1 className="text-center mb-5">Browse Courses</h1>
      <Row>
        {courses.map((course) => (
          <Col md={4} className="mb-4" key={course.id}>
            <Card className="shadow-sm border-0">
              <img src={course.image} alt={course.title} className="card-img-top" />
              <CardBody>
                <CardTitle tag="h5">{course.title}</CardTitle>
                <CardText>
                  <strong>Category:</strong> {course.category}
                  <br />
                  <strong>Price:</strong> {course.price}
                  <br />
                  <strong>Chapters:</strong> {course.chapters}
                  <br />
                  <strong>Description:</strong> {course.description.slice(0, 50)}...
                </CardText>
                <div className="mb-3">
                  <strong>Progress:</strong>
                  <Progress value={course.progress}>{course.progress}%</Progress>
                </div>
                <Button
                  color="primary"
                  block
                  onClick={() => navigate(`/course/${course.id}`)} // Yönlendirme
                >
                  View Details
                </Button>
              </CardBody>
            </Card>
          </Col>
        ))}
      </Row>
    </Container>
  );
};

export default HomePage;
