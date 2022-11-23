export class Student
{
	id: number;
	name: string| null;
	address: string | null;
	dateOfBirth: Date | null;
	
	constructor() {
		this.id = 0;
		this.name = null;
		this.address = null;
		this.dateOfBirth = null;
	}
}