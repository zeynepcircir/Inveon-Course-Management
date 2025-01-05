import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Card, CardBody, CardTitle, CardText, Button, Progress } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import axiosInstance from '../../api/axios'; 
import API_ENDPOINTS from '../../api/endpoints'; 

const DashboardPage = () => {
  const navigate = useNavigate();

  const [courses, setCourses] = useState([]);

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const response = await axiosInstance.get(API_ENDPOINTS.course.enrolledCourses);
        setCourses(response.data.data); 
      } catch (error) {
        console.error('Error fetching courses:', error);
      }
    };

    fetchCourses();
  }, []);

  return (
    <Container className="py-5">
      <section className="mb-5">
        {courses.length > 0 ? (
          <Row>
            {courses.map((course) => (
              <Col md={4} className="mb-4" key={course.id}>
                <Card className="shadow-sm border-0">
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
