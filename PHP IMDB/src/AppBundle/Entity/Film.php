<?php

namespace AppBundle\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Film
 *
 * @ORM\Table(name="films")
 * @ORM\Entity(repositoryClass="AppBundle\Repository\FilmRepository")
 */
class Film
{
    /**
     * @var int
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="AUTO")
     * @ORM\Column(type = "integer")
     */
    private $id;

    /**
     * @var string
     * @ORM\Column(name = "name", type="string", length=255, nullable=false)
     *
     */
    private $name;

    /**
     *
     * @var string
     * @ORM\Column(name="genre", type="string", length=255, nullable=false)
     *
     */
    private $genre;

    /**
     * @var string
     * @ORM\Column(name="director", type="string", length=255, nullable=false)
     *
     */
    private $director;

    /**
     * @var int
     * @ORM\Column(name="year")
     */
    private $year;

    /**
     * @return int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * @param int $id
     */
    public function setId($id)
    {
        $this->id = $id;
    }


    /**
     * @return string
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @param string $name
     * @return Film;
     */
    public function setName($name)
    {
        $this->name = $name;
        return $this;
    }

    /**
     * @return string
     */
    public function getGenre()
    {
        return $this->genre;
    }

    /**
     * @param string $genre
     * @return Film;
     */
    public function setGenre($genre)
    {
        $this->genre = $genre;
        return $this;
    }

    /**
     * @return string
     */
    public function getDirector()
    {
        return $this->director;
    }

    /**
     * @param string $director
     * @return Film;
     */
    public function setDirector($director)
    {
        $this->director = $director;
        return $this;
    }

    /**
     * @return mixed
     */
    public function getYear()
    {
        return $this->year;
    }

    /**
     * @param int $year
     * @return Film
     */
    public function setYear($year)
    {
        $this->year = $year;
        return $this;
    }


}

