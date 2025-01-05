import React, { useState, useEffect } from 'react';
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
import { useNavigate } from 'react-router-dom';
import axiosInstance from '../../api/axios'; 
import API_ENDPOINTS from '../../api/endpoints'; 

const AddCoursePage = () => {
  const navigate = useNavigate();
  const [currentStep, setCurrentStep] = useState(1);
  const [courseData, setCourseData] = useState({
    title: '',
    description: '',
    imageUrl: null,
    categoryId: '',
    price: '',
  });
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await axiosInstance.get(API_ENDPOINTS.category.getAll);
        setCategories(response.data.data); 
        console.log("Categories: ", response.data.data)
      } catch (error) {
        console.error('Error fetching categories:', error);
      }
    };

    fetchCategories();
  }, []);
  
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCourseData({ ...courseData, [name]: value });
  };

  const handleImageUpload = (e) => {
    setCourseData({ ...courseData, imageUrl: e.target.files[0].name });
  };

  const nextStep = () => setCurrentStep((prev) => prev + 1);
  const prevStep = () => setCurrentStep((prev) => prev - 1);

  const handleSubmit = async () => {
    try {
      const response = await axiosInstance.post(API_ENDPOINTS.course.create,courseData);
      alert("Product is created succeessfully!");
      navigate('/teacher');
      console.log('Created product: ', response.data.data);
    } catch (error) {
      console.error('Error creating course:', error);
    }
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
                        name="categoryId"
                        id="category"
                        value={courseData.categoryId}
                        onChange={handleInputChange}
                      >
                        <option value="">Select a category</option>
                        {categories.map((category) => (
                          <option key={category.id} value={category.id}>
                            {category.name}
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
