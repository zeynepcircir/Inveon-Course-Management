import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AppNavbar from './components/Navbar/Navbar';
import HomePage from './pages/HomePage/HomePage';
import CourseDetailPage from './pages/CourseDetailPage/CourseDetailPage';
import LoginPage from './pages/LoginPage/LoginPage';
import RegisterPage from './pages/RegisterPage/RegisterPage';
import TeacherPage from './pages/TeacherPage/TeacherPage';
import DashboardPage from './pages/DashboardPage/DashboardPage';
import AddCoursePage from './pages/AddCoursePage/AddCoursePage';
import EditCoursePage from './pages/EditCoursePage/EditCoursePage';

function App() {
  return (
    <Router>
      <div className="App">
        <AppNavbar /> {/* Navbar burada eklendi */}
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/course/:id" element={<CourseDetailPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/browse" element={<HomePage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/dashboard" element={<DashboardPage />} />
          <Route path="/teacher" element={<TeacherPage />} />
          <Route path="/teacher/add" element={<AddCoursePage />} />
          <Route path="/teacher/edit/:id" element={<EditCoursePage />} />
        </Routes> 
      </div>
    </Router>
  );
}

export default App;
