-- Voer uit als root in sys schema
CREATE SCHEMA ShopGent;
CREATE USER 'shopgent' IDENTIFIED BY 'shopgent';
GRANT ALL PRIVILEGES ON ShopGent.* TO 'shopgent';