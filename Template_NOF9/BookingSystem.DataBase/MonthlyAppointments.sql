select  DateofAppointment, Timeslot, FullName
from Appointments , Pupils
where DateofAppointment  between '2017/10/1' and '2017/10/31' and Appointments.PupilId = Pupils.Id