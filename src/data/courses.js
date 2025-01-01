import x from '../assets/x.webp';
import y from '../assets/y.jpg';
import z from '../assets/z.jpeg';
import h from '../assets/h.jpeg';
import g from '../assets/g.jpg';
import f from '../assets/f.jpeg';


const courses = [
    {
      id: 1,
      title: 'Cinematic Techniques',
      category: 'Filming',
      price: 'Free',
      progress: 100,
      chapters: ['Introduction', 'Lighting Basics', 'Camera Angles', 'Advanced Techniques'],
      image: x,
      description: 'Learn the best cinematic techniques to make your videos look professional.',
      purchased: true,
    },
    {
      id: 2,
      title: 'Introduction to Filming',
      category: 'Filming',
      price: '$20',
      progress: 50,
      chapters: ['Overview', 'Getting Started filming and video production'],
      image: y,
      description: 'A beginner-friendly course to get started with filming and video production.',
      purchased: false,
    },
    {
      id: 3,
      title: 'Structural Design Principles',
      category: 'Engineering',
      price: '$15',
      progress: 30,
      chapters: ['Introduction', 'Load Analysis', 'Design Methods', 'Case Studies'],
      image: z,
      description: 'Master the principles of structural design and engineering fundamentals.',
      purchased: true,
    },
    {
      id: 4,
      title: 'Introduction to Accounting',
      category: 'Accounting',
      price: '$25',
      progress: 0,
      chapters: ['Introduction', 'Basics', 'Financial Analysis'],
      image: f,
      description: 'An introductory course to learn the fundamentals of accounting and finance.',
      purchased: false,
    },
    {
      id: 5,
      title: 'Advanced Tax Accounting',
      category: 'Accounting',
      price: '$50',
      progress: 70,
      chapters: ['Advanced Taxation', 'Corporate Finance'],
      image: h,
      description: 'Learn advanced tax accounting principles and corporate finance techniques.',
      purchased: false,
    },
    {
      id: 6,
      title: 'Modern Filming Techniques',
      category: 'Filming',
      price: '$30',
      progress: 20,
      chapters: ['Modern Techniques', 'Editing Basics'],
      image: g,
      description: 'Explore modern filming techniques and basic editing skills.',
      purchased: false,
    },
  ];
  
  export default courses;
  