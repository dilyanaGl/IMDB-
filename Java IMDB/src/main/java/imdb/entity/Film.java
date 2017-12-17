package imdb.entity;

import javax.persistence.*;

@Entity
@Table(name = "films")
public class Film {
	private Integer id;
	private String Name;
	private String Director;
	private String Genre;
	private Integer Year;

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(nullable = false)
    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    @Column(nullable = false)
    public String getDirector() {
        return Director;
    }

    public void setDirector(String director) {
        Director = director;
    }

    @Column(nullable = false)
    public String getGenre() {
        return Genre;
    }

    public void setGenre(String genre) {
        Genre = genre;
    }

    @Column(nullable = false)
    public Integer getYear() {
        return Year;
    }

    public void setYear(Integer year) {
        Year = year;
    }

    public Film(String name, String director, String genre, Integer year) {
        this.Name = name;
        this.Director = director;
        this.Genre = genre;
        this.Year = year;
    }

    public Film() {

    }
}
