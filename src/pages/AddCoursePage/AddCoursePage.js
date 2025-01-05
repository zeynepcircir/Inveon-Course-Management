import React, { useState } from 'react';
import {
  Container,
  Row,
  Col,
  Card,
  CardBody,
  CardTitle,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  Progress,
} from 'reactstrap';

const AddCoursePage = () => {
  const [currentStep, setCurrentStep] = useState(1);
  const [courseData, setCourseData] = useState({
    title: '',
    description: '',
    image: null,
    category: '',
    price: '',
  });

  const categories = ['Filming', 'Engineering', 'Accounting', 'Design', 'Marketing'];

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCourseData({ ...courseData, [name]: value });
  };

  const handleImageUpload = (e) => {
    setCourseData({ ...courseData, image: e.target.files[0] });
  };

  const nextStep = () => setCurrentStep((prev) => prev + 1);
  const prevStep = () => setCurrentStep((prev) => prev - 1);

  const handleSubmit = () => {
    alert('Course submitted successfully!');
    console.log(courseData);
  };

  return (
    <Container className="py-5">
      <Row className="justify-content-center" style={{ minHeight: '70vh', alignItems: 'center' }}>
        <Col md={6} lg={5}>
          <Card
            className="shadow-lg"
            style={{
              borderRadius: '15px',
              padding: '20px',
              maxWidth: '100%',
              minHeight: '350px',
            }}
          >
            <CardBody>
              <Progress value={(currentStep / 5) * 100} className="mb-4" />

              {currentStep === 1 && (
                <div>
                  <CardTitle tag="h4" className="mb-3">Step 1: Course Title</CardTitle>
                  <Form>
                    <FormGroup>
                      <Label for="title">Course Title</Label>
                      <Input
                        type="text"
                        name="title"
                        id="title"
                        placeholder="Enter course title"
                        value={courseData.title}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Form>
                </div>
              )}

              {currentStep === 2 && (
                <div>
                  <CardTitle tag="h4" className="mb-3">Step 2: Course Description</CardTitle>
                  <Form>
                    <FormGroup>
                      <Label for="description">Description</Label>
                      <Input
                        type="textarea"
                        name="description"
                        id="description"
                        placeholder="Enter course description"
                        value={courseData.description}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Form>
                </div>
              )}

              {currentStep === 3 && (
                <div>
                  <CardTitle tag="h4" className="mb-3">Step 3: Upload Image</CardTitle>
                  <Form>
                    <FormGroup>
                      <Label for="image">Course Image</Label>
                      <Input
                        type="file"
                        name="image"
                        id="image"
                        onChange={handleImageUpload}
                      />
                    </FormGroup>
                  </Form>
                </div>
              )}

              {currentStep === 4 && (
                <div>
                  <CardTitle tag="h4" className="mb-3">Step 4: Category</CardTitle>
                  <Form>
                    <FormGroup>
                      <Label for="category">Category</Label>
                      <Input
                        type="select"
                        name="category"
                        id="category"
                        value={courseData.category}
                        onChange={handleInputChange}
                      >
                        <option value="">Select a category</option>
                        {categories.map((category, index) => (
                          <option key={index} value={category}>
                            {category}
                          </option>
                        ))}
                      </Input>
                    </FormGroup>
                  </Form>
                </div>
              )}

              {currentStep === 5 && (
                <div>
                  <CardTitle tag="h4" className="mb-3">Step 5: Price</CardTitle>
                  <Form>
                    <FormGroup>
                      <Label for="price">Price</Label>
                      <Input
                        type="number"
                        name="price"
                        id="price"
                        placeholder="Enter course price"
                        value={courseData.price}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Form>
                </div>
              )}

              <div className="d-flex justify-content-between mt-4">
                <Button
                  color="secondary"
                  onClick={prevStep}
                  disabled={currentStep === 1}
                >
                  Previous
                </Button>
                {currentStep < 5 ? (
                  <Button color="primary" onClick={nextStep}>
                    Next
                  </Button>
                ) : (
                  <Button color="success" onClick={handleSubmit}>
                    Submit
                  </Button>
                )}
              </div>
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default AddCoursePage;
