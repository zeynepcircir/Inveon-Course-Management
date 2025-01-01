import React from 'react';
import { Container, Row, Col, Card, CardBody, CardTitle, CardText, Button, Progress } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import courses from '../../data/courses'; 

const DashboardPage = () => {
  const navigate = useNavigate();

  // Satın alınan ve satın alınmayan kursları ayır
  const purchasedCourses = courses.filter((course) => course.purchased);

  return (
    <Container className="py-5">
      {/* Satın Alınan Kurslar */}
      <section className="mb-5">
        {purchasedCourses.length > 0 ? (
          <Row>
            {purchasedCourses.map((course) => (
              <Col md={4} className="mb-4" key={course.id}>
                <Card className="shadow-sm border-0">
                  {/* Görsel: Bootstrap sınıfları ve sabit boyutlar */}
                  <img 
                    src={course.image} 
                    alt={course.title} 
                    className="card-img-top img-fluid rounded"
                    style={{ height: '200px', objectFit: 'cover' }}
                  />
                  <CardBody>
                    <CardTitle tag="h5" className="text-dark fw-bold">{course.title}</CardTitle>
                    <CardText>
                      <strong>Category:</strong> {course.category}
                      <br />
                      <strong>Price:</strong> {course.price}
                    </CardText>
                    <div className="mb-3">
                      <strong>Progress:</strong>
                      <Progress value={course.progress}>{course.progress}%</Progress>
                    </div>
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
    </Container>
  );
};

export default DashboardPage;
