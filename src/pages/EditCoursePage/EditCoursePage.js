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
} from 'reactstrap';
import { useParams } from 'react-router-dom';
import courses from '../../data/courses';

const EditCoursePage = () => {
  const { id } = useParams();
  const [courseData, setCourseData] = useState(null);
  const [previewImage, setPreviewImage] = useState(null);

  const categories = ['Filming', 'Engineering', 'Accounting', 'Design', 'Marketing'];

  useEffect(() => {
    const course = courses.find((c) => c.id === parseInt(id));
    if (course) {
      setCourseData({
        title: course.title,
        description: course.description,
        image: course.image,
        category: course.category,
        price: course.price.replace('$', ''),
      });
      setPreviewImage(course.image);
    } else {
      alert('Course not found!');
    }
  }, [id]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCourseData({ ...courseData, [name]: value });
  };

  const handleImageUpload = (e) => {
    const file = e.target.files[0];
    if (file && file.type.startsWith('image/')) {
      setCourseData({ ...courseData, image: file });
      setPreviewImage(URL.createObjectURL(file));
    } else {
      alert('Please upload a valid image file (e.g., .jpg, .png).');
    }
  };

  const handleSubmit = () => {
    alert('Course updated successfully!');
    console.log(courseData);
  };

  if (!courseData) return <p>Loading course data...</p>;

  return (
    <Container className="py-5">
      <Row className="justify-content-center">
        <Col md={8}>
          <Card className="shadow-lg" style={{ borderRadius: '15px', padding: '20px' }}>
            <CardBody>
              <CardTitle tag="h4" className="mb-4 text-center">
                Edit Course
              </CardTitle>
              <Form>
                <FormGroup>
                  <Label for="title">Course Title</Label>
                  <Input
                    type="text"
                    name="title"
                    id="title"
                    value={courseData.title}
                    onChange={handleInputChange}
                  />
                </FormGroup>
                <FormGroup>
                  <Label for="description">Description</Label>
                  <Input
                    type="textarea"
                    name="description"
                    id="description"
                    value={courseData.description}
                    onChange={handleInputChange}
                  />
                </FormGroup>
                <FormGroup>
                  <Label for="image">Upload Image</Label>
                  <Input type="file" id="image" onChange={handleImageUpload} />
                  {previewImage && (
                    <div className="mt-3 text-center">
                      <img
                        src={previewImage}
                        alt="Preview"
                        style={{
                          width: '100%',
                          maxWidth: '500px',
                          height: 'auto',
                          borderRadius: '10px',
                          marginTop: '15px',
                        }}
                      />
                    </div>
                  )}
                </FormGroup>
                <FormGroup>
                  <Label for="category">Category</Label>
                  <Input
                    type="select"
                    name="category"
                    id="category"
                    value={courseData.category}
                    onChange={handleInputChange}
                  >
                    {categories.map((category, index) => (
                      <option key={index} value={category}>
                        {category}
                      </option>
                    ))}
                  </Input>
                </FormGroup>
                <FormGroup>
                  <Label for="price">Price</Label>
                  <Input
                    type="number"
                    name="price"
                    id="price"
                    value={courseData.price}
                    onChange={handleInputChange}
                  />
                </FormGroup>
                <Button color="success" block onClick={handleSubmit}>
                  Save Changes
                </Button>
              </Form>
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default EditCoursePage;
