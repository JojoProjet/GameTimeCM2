CREATE TABLE User (
    Id INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Score INT NOT NULL DEFAULT 0,
    Time INT NOT NULL DEFAULT 0,
    PRIMARY KEY(Id)
)