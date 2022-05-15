using Npgsql;
using System.Data;

namespace TugasPbo
{
    class getting_data
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=ananda31;database=tugaspbo;");
        }
        public bool ExecuteQuery(out bool info)

        {
            info = true;
            try
            {

                NpgsqlConnection con = koneksi();
                con.Open();
                string sql = "select * from pegawai";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return info;

            }
            catch (Exception)
            {
                info = false;
                return info;
            }

        }
    }
    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=ananda31;database=tugaspbo;");
        }
        public bool insert(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into pegawai(id_pegawai,nama,no_telepon) values('3','Ananda','081234567890')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }

        public bool update(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update pegawai set nama = Salsa, no_telepon = 081234468914 where id_pegawai = 3", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }
        public bool Delete(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from pegawai where id_pegawai = 3", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }
    }

    class program_utama
    {

        static void Main(string[] args)
        {
            bool info;
            bool ingfo = false;
            getting_data dat = new getting_data();
            operasi op = new operasi();
            if (dat.ExecuteQuery(out info) == true)
            {
                Console.WriteLine("Berhasil Mengambil Data!");
            }
            else if (dat.ExecuteQuery(out info) == false)
            {
                Console.WriteLine("Gagal Mengambil Data!");
            }
            if (op.insert(ref ingfo) == true)
            {
                Console.WriteLine("Insert Berhasil!");
            }
            else if (op.insert(ref ingfo) == false)
            {
                Console.WriteLine("Insert Gagal!");
            }
            if (op.update(ref ingfo) == true)
            {
                Console.WriteLine("Update Berhasil!");
            }
            else if (op.update(ref ingfo) == false)
            {
                Console.WriteLine("Update Gagal!");
            }
            if (op.Delete(ref ingfo) == true)
            {
                Console.WriteLine("Berhasil Dihapus!");
            }
            else if (op.Delete(ref ingfo) == false)
            {
                Console.WriteLine("Gagal Dihapus!");
            }
        }
    }
}