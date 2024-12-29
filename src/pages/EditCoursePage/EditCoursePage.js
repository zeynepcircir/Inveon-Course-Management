import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { Container, Form, FormGroup, Label, Input, Button } from 'reactstrap';

// Mock veri (backend ile değiştirilebilir)
const courses = [
  { id: 1, title: 'Cinematic Techniques', category: 'Filming', price: 'Free', description: 'Learn about cinematic techniques.' },
  { id: 2, title: 'Introduction to Filming', category: 'Filming', price: '$20', description: 'An introductory course on filming.' },
  { id: 3, title: 'Structural Design Principles', category: 'Engineering', price: '$15', description: 'Learn structural design principles.' },
];

const EditCoursePage = () => {
  const { id } = useParams(); // URL'den kurs ID'sini al
  const [courseData, setCourseData] = useState({
    title: '',
    category: '',
    price: '',
    description: '',
  });

  // Kursu ID ile bul ve state'e yerleştir
  useEffect(() => {
    const course = courses.find((c) => c.id === parseInt(id));
    if (course) {
      setCourseData(course);
    }
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCourseData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log('Updated course data:', courseData);
    alert('Course updated successfully!');
  };

  return (
    <Container className="py-5">
      <h1 className="text-center mb-4">Edit Course</h1>
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="title">Course Title</Label>
          <Input
            type="text"
            id="title"
            name="title"
            placeholder="Enter course title"
            value={courseData.title}
            onChange={handleChange}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="category">Category</Label>
          <Input
            type="text"
            id="category"
            name="category"
            placeholder="Enter course category"
            value={courseData.category}
            onChange={handleChange}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="price">Price</Label>
          <Input
            type="text"
            id="price"
            name="price"
            placeholder="Enter course price"
            value={courseData.price}
            onChange={handleChange}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="description">Description</Label>
          <Input
            type="textarea"
            id="description"
            name="description"
            placeholder="Enter course description"
            value={courseData.description}
            onChange={handleChange}
            required
          />
        </FormGroup>
        <Button color="primary" type="submit" block>
          Save Changes
        </Button>
      </Form>
    </Container>
  );
};

export default EditCoursePage;
