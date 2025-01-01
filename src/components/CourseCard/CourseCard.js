import React from 'react';
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';
import { useCart } from '../../context/CartContext';

const CourseCard = ({ course, onViewDetails }) => {
  const { addToCart } = useCart();

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
        <Button color="success" className="mt-2" onClick={() => addToCart(course)}>
          Add to Cart
        </Button>
      </CardBody>
    </Card>
  );
};

export default CourseCard;
