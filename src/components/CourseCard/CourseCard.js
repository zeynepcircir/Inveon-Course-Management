import React from 'react';
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';

const CourseCard = ({ course, onViewDetails }) => {
  return (
    <Card className="shadow-sm mb-4">
      <img src={course.image} alt={course.title} className="card-img-top" />
      <CardBody>
        <CardTitle tag="h5">{course.title}</CardTitle>
        <CardText>
          <strong>Category:</strong> {course.category}
          <br />
          <strong>Price:</strong> {course.price}
        </CardText>
        <Button color="primary" onClick={() => onViewDetails(course.id)}>
          View Details
        </Button>
      </CardBody>
    </Card>
  );
};

export default CourseCard;
