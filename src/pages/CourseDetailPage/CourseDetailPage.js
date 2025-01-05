import React, { useState } from 'react';
import {
  Container,
  Row,
  Col,
  ListGroup,
  ListGroupItem,
  Alert,
  Button,
} from 'reactstrap';
import { useParams, useNavigate } from 'react-router-dom';

const CourseDetail = () => {
  const { courseId } = useParams();
  const navigate = useNavigate();

  const [isPurchased, setIsPurchased] = useState(false);
  const chapters = [
    { id: 1, title: 'Introduction', duration: '01:05', isLocked: false },
    { id: 2, title: 'Deep Dive', duration: '03:15', isLocked: true },
    { id: 3, title: 'Exploring the Basics', duration: '02:45', isLocked: true },
    { id: 4, title: 'Outro', duration: '00:45', isLocked: true },
  ];

  const handleVideoClick = (chapter) => {
    if (!isPurchased && chapter.isLocked) {
      alert('Bu bölümü izlemek için kursu satın almanız gerekiyor.');
    } else {
      alert(`${chapter.title} oynatılıyor...`);
    }
  };

  return (
    <Container className="py-5">
      <Row>
        <Col md={4}>
          <h4>Course Chapters</h4>
          <ListGroup>
            {chapters.map((chapter, index) => (
              <ListGroupItem
                key={chapter.id}
                className="d-flex justify-content-between align-items-center"
                onClick={() => handleVideoClick(chapter)}
                style={{
                  cursor: 'pointer',
                  opacity: chapter.isLocked && !isPurchased ? 0.5 : 1,
                }}
              >
                {chapter.isLocked && !isPurchased ? (
                  <>
                    <span>{chapter.title}</span>
                    <i className="bi bi-lock-fill text-secondary"></i>
                  </>
                ) : (
                  <span>{chapter.title}</span>
                )}
                <small>{chapter.duration}</small>
              </ListGroupItem>
            ))}
          </ListGroup>
        </Col>
        <Col md={8}>
          {isPurchased ? (
            <div>
              <video
                controls
                width="100%"
                style={{ maxHeight: '400px', background: '#000' }}
              >
                <source src="https://www.w3schools.com/html/mov_bbb.mp4" type="video/mp4" />
                Your browser does not support the video tag.
              </video>
            </div>
          ) : (
            <div className="text-center">
              <Alert color="warning" className="my-3">
                You need to purchase this course to watch locked chapters.
              </Alert>
              <div
                className="d-flex justify-content-center align-items-center"
                style={{
                  height: '300px',
                  background: '#f8f9fa',
                  border: '1px solid #ddd',
                  borderRadius: '5px',
                }}
              >
                <i className="bi bi-lock-fill" style={{ fontSize: '3rem', color: '#aaa' }}></i>
                <p className="ms-3 text-muted">This chapter is locked</p>
              </div>
            </div>
          )}
        </Col>
      </Row>
    </Container>
  );
};

export default CourseDetail;
