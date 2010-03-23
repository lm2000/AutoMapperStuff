
using System;
using AutoMapper;
namespace AutoMapperStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task
            {
                Name = "Task1",
                Priority = new TaskPriority("High"),
                DueTo = DateTime.Now.AddDays(1.0)
            };

            TaskDto taskdto1 = MapManual(task);


            //InitMappins();
            InitCustomMappins();
            TaskDto taskdto = Mapper.Map<Task, TaskDto>(task);
        }



        public static TaskDto MapManual(Task task)
        {
            return new TaskDto
            {
                Name = task.Name,
                DueTo = task.DueTo.ToLongDateString(),
                Details = task.GetDetails(),
                PriorityCaption = task.Priority.Caption

            };
        }


        public static void InitMappins()
        {
            Mapper.CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            Mapper.CreateMap<Task, TaskDto>();
            Mapper.AssertConfigurationIsValid();
        }

        public static void InitCustomMappins()
        {
            Mapper.CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            Mapper.CreateMap<Task, TaskDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DueTo, opt => opt.MapFrom(src => src.DueTo))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.GetDetails()))
                .ForMember(dest => dest.PriorityCaption, opt => opt.MapFrom(src => src.Priority.Caption));

            Mapper.AssertConfigurationIsValid();
        }

        //Perfom mapping
        public static TaskDto Map(Task task)
        {
            return Mapper.Map<Task, TaskDto>(task);
        }

        public class DateTimeTypeConverter : TypeConverter<DateTime, string>
        {
            protected override string ConvertCore(DateTime source)
            {
                return source.ToLongDateString();
            }
        }

    }
}
