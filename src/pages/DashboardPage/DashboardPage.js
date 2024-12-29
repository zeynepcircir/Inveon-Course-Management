import React from 'react';
import { Container, Row, Col, Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

// Mock veri (backend ile değiştirilebilir)
const courses = [
  {
    id: 1,
    title: 'Cinematic Techniques',
    category: 'Filming',
    price: 'Free',
    chapters: ['Introduction', 'Lighting Basics', 'Camera Angles', 'Advanced Techniques'],
    purchased: true, // Satın alınmış
    image: 'https://via.placeholder.com/150',
  },
  {
    id: 2,
    title: 'Introduction to Filming',
    category: 'Filming',
    price: '$20',
    chapters: ['Overview', 'Getting Started'],
    purchased: false, // Satın alınmamış
    image: 'https://via.placeholder.com/150',
  },
  {
    id: 3,
    title: 'Structural Design Principles',
    category: 'Engineering',
    price: '$15',
    chapters: ['Introduction', 'Load Analysis', 'Design Methods', 'Case Studies'],
    purchased: true, // Satın alınmış
    image: 'https://via.placeholder.com/150',
  },
];

const DashboardPage = () => {
  const navigate = useNavigate();

  // Satın alınan ve satın alınmayan kursları ayır
  const purchasedCourses = courses.filter((course) => course.purchased);
  const availableCourses = courses.filter((course) => !course.purchased);

  return (
    <Container className="py-5">
      <h1 className="text-center mb-5">My Dashboard</h1>

      {/* Satın Alınan Kurslar */}
      <section className="mb-5">
        <h2 className="mb-4">Purchased Courses</h2>
        {purchasedCourses.length > 0 ? (
          <Row>
            {purchasedCourses.map((course) => (
              <Col md={4} className="mb-4" key={course.id}>
                <Card className="shadow-sm border-0">
                  <img src={course.image} alt={course.title} className="card-img-top" />
                  <CardBody>
                    <CardTitle tag="h5">{course.title}</CardTitle>
                    <CardText>
                      <strong>Category:</strong> {course.category}
                      <br />
                      <strong>Price:</strong> {course.price}
                    </CardText>
                    <Button
                      color="success"
                      block
                      onClick={() => navigate(`/course/${course.id}`)}
                    >
                      View Content
                    </Button>
                  </CardBody>
                </Card>
              </Col>
            ))}
          </Row>
        ) : (
          <p className="text-muted">You have not purchased any courses yet.</p>
        )}
      </section>

      {/* Satın Alınmayan Kurslar */}
      <section>
        <h2 className="mb-4">Available Courses</h2>
        {availableCourses.length > 0 ? (
          <Row>
            {availableCourses.map((course) => (
              <Col md={4} className="mb-4" key={course.id}>
                <Card className="shadow-sm border-0">
                  <img src={course.image} alt={course.title} className="card-img-top" />
                  <CardBody>
                    <CardTitle tag="h5">{course.title}</CardTitle>
                    <CardText>
                      <strong>Category:</strong> {course.category}
                      <br />
                      <strong>Price:</strong> {course.price}
                    </CardText>
                    <Button
                      color="primary"
                      block
                      onClick={() => navigate(`/payment/${course.id}`)}
                    >
                      Enroll for {course.price}
                    </Button>
                  </CardBody>
                </Card>
              </Col>
            ))}
          </Row>
        ) : (
          <p className="text-muted">All courses are purchased.</p>
        )}
      </section>
    </Container>
  );
};

export default DashboardPage;
