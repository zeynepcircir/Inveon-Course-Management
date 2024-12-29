import React, { useState } from 'react';
import { Container, Form, FormGroup, Label, Input, Button } from 'reactstrap';

const AddCoursePage = () => {
  const [title, setTitle] = useState('');
  const [category, setCategory] = useState('');
  const [price, setPrice] = useState('');
  const [description, setDescription] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log({
      title,
      category,
      price,
      description,
    });
    alert('Course added successfully!');
  };

  return (
    <Container className="py-5">
      <h1 className="text-center mb-4">Add New Course</h1>
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="title">Course Title</Label>
          <Input
            type="text"
            id="title"
            placeholder="Enter course title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="category">Category</Label>
          <Input
            type="text"
            id="category"
            placeholder="Enter course category"
            value={category}
            onChange={(e) => setCategory(e.target.value)}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="price">Price</Label>
          <Input
            type="text"
            id="price"
            placeholder="Enter course price"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="description">Description</Label>
          <Input
            type="textarea"
            id="description"
            placeholder="Enter course description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            required
          />
        </FormGroup>
        <Button color="primary" type="submit" block>
          Add Course
        </Button>
      </Form>
    </Container>
  );
};

export default AddCoursePage;
