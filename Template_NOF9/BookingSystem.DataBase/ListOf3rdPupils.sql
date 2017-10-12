select FullName
from Pupils
Where Pupils.Form = 0
-- This is a list of all pupils from a year group. 
-- Staff can refur to this when giving items to every pupil of a certain year group e.g. stationary packs
-- Staff were unable to do this before without contacting admissions dep. this will be quicker and esier
-- form is zero because the database converts enums to an integer so the firs yeargroup is represented with a 0