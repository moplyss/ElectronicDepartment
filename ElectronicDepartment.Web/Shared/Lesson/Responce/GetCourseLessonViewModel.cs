﻿using ElectronicDepartment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDepartment.Web.Shared.Lesson.Responce
{
    public class GetCourseLessonViewModel
    {
        public int Id { get; set; }

        public string TeacherId { get; set;  }

        public string TeacherFullName { get; set; }

        public LessonType LessonType { get; set; }

        public DateTime LessonStart { get; set; }

        public int Duration { get; set; }

        public int TotalStudentOnLesson { get; set; }
    }
}
