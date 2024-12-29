import React from 'react';
import { Container, Button, Table } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import alertify from 'alertifyjs';

// Mock veri (backend ile değiştirilebilir)
const courses = [
  { id: 1, title: 'Cinematic Techniques', category: 'Filming', price: 'Free' },
  { id: 2, title: 'Introduction to Filming', category: 'Filming', price: '$20' },
  { id: 3, title: 'Structural Design Principles', category: 'Engineering', price: '$15' },
];

const TeacherPage = () => {
  const navigate = useNavigate();

  const handleEdit = (id) => {
    navigate(`/teacher/edit/${id}`);
  };

  const handleDelete = (id) => {
    alertify.confirm(
      'Delete Course',
      `Are you sure you want to delete the course with ID: ${id}?`,
      () => {
        alertify.success('Course deleted successfully!');
        // Backend'de silme işlemi yapılabilir
      },
      () => {
        alertify.error('Delete operation canceled.');
      }
    ).set('labels', { ok: 'Yes', cancel: 'No' }).set('movable', false).set('position', 'top-right');
  };

  const handleAddCourse = () => {
    navigate('/teacher/add');
  };

  return (
    <Container className="py-5">
      <h1 className="text-center mb-5">Manage Your Courses</h1>
      <Button color="success" className="mb-4" onClick={handleAddCourse}>
        Add New Course
      </Button>
      <Table bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Title</th>
            <th>Category</th>
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {courses.map((course, index) => (
            <tr key={course.id}>
              <th scope="row">{index + 1}</th>
              <td>{course.title}</td>
              <td>{course.category}</td>
              <td>{course.price}</td>
              <td>
                <Button color="warning" size="sm" onClick={() => handleEdit(course.id)}>
                  Edit
                </Button>{' '}
                <Button color="danger" size="sm" onClick={() => handleDelete(course.id)}>
                  Delete
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </Container>
  );
};

export default TeacherPage;
