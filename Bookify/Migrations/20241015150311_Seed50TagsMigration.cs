using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
	/// <inheritdoc />
	public partial class Seed50TagsMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
			   table: "Tags",
			   columns: new[] { "TagName" },
			   values: new object[,]
			   {
					{ "Machine Learning" },
					{ "Artificial Intelligence" },
					{ "Blockchain" },
					{ "Cybersecurity" },
					{ "Cloud Computing" },
					{ "Internet of Things" },
					{ "Mobile Development" },
					{ "Data Science" },
					{ "DevOps" },
					{ "Microservices" },
					{ "UI/UX Design" },
					{ "Digital Marketing" },
					{ "Big Data" },
					{ "Augmented Reality" },
					{ "Virtual Reality" },
					{ "Software Architecture" },
					{ "Agile Development" },
					{ "Scrum" },
					{ "Product Management" },
					{ "System Design" },
					{ "Technical Writing" },
					{ "Open Source" },
					{ "SEO" },
					{ "E-commerce" },
					{ "Game Design" },
					{ "Mobile Apps" },
					{ "Project Management" },
					{ "Networking" },
					{ "Database Management" },
					{ "Quality Assurance" },
					{ "Human-Computer Interaction" },
					{ "Robotics" },
					{ "Data Visualization" },
					{ "Testing Automation" },
					{ "User Experience" },
					{ "User Interface" },
					{ "Ethical Hacking" },
					{ "IT Support" },
					{ "Digital Transformation" },
					{ "Business Intelligence" },
					{ "Content Management Systems" },
					{ "Data Mining" },
					{ "Natural Language Processing" },
					{ "Computer Vision" },
					{ "Wearable Technology" },
					{ "Technical Support" },
					{ "Augmented Analytics" },
					{ "Virtualization" },
					{ "Remote Work" },
					{ "Health Tech" },
					{ "FinTech" },
					{ "EdTech" },
					{ "Agile Methodologies" },
					{ "Systems Engineering" }
			   });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
			   table: "Tags",
			   keyColumn: "TagName",
			   keyValues: new object[]
			   {
					"Machine Learning", "Artificial Intelligence", "Blockchain",
					"Cybersecurity", "Cloud Computing", "Internet of Things",
					"Mobile Development", "Data Science", "DevOps", "Microservices",
					"UI/UX Design", "Digital Marketing", "Big Data", "Augmented Reality",
					"Virtual Reality", "Software Architecture", "Agile Development",
					"Scrum", "Product Management", "System Design", "Technical Writing",
					"Open Source", "SEO", "E-commerce", "Game Design", "Mobile Apps",
					"Project Management", "Networking", "Database Management",
					"Quality Assurance", "Human-Computer Interaction", "Robotics",
					"Data Visualization", "Testing Automation", "User Experience",
					"User Interface", "Ethical Hacking", "IT Support", "Digital Transformation",
					"Business Intelligence", "Content Management Systems", "Data Mining",
					"Natural Language Processing", "Computer Vision", "Wearable Technology",
					"Technical Support", "Augmented Analytics", "Virtualization",
					"Remote Work", "Health Tech", "FinTech", "EdTech",
					"Agile Methodologies", "Systems Engineering"
			   });
		}
	}
}
